using Microsoft.ML;

namespace MLNetPOC;

class Program
{
    static void Main(string[] args)
    {
        var context = new MLContext();

        // Verificar el directorio de ejecución
        Console.WriteLine($"Current Directory: {Environment.CurrentDirectory}");

        // Verificar si el archivo existe
        string dataPath = @"C:\Projects\DotNet\MachineLearning\MLNetPOC\data.csv";
        if (!System.IO.File.Exists(dataPath))
        {
            Console.WriteLine($"File not found: {dataPath}");
            return;
        }

        // Carga de datos
        Console.WriteLine("Loading data...");
        var data = context.Data.LoadFromTextFile<CustomerData>(dataPath, separatorChar: ',', hasHeader: true);

        // Definición del pipeline
        Console.WriteLine("Defining pipeline...");
        var pipeline = context.Transforms.Concatenate("Features", "Age", "Salary")
            .Append(context.Transforms.NormalizeMinMax("Features"))
            .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Purchase", featureColumnName: "Features"));

        // Validación cruzada en lugar de división en entrenamiento/prueba
        Console.WriteLine("Cross-validating model...");
        var crossValidationResults = context.BinaryClassification.CrossValidate(data, pipeline, numberOfFolds: 5, labelColumnName: "Purchase");

        // Mostrar resultados de cada fold
        foreach (var result in crossValidationResults)
        {
            Console.WriteLine($"Fold: {result.Fold}, Accuracy: {result.Metrics.Accuracy:P2}, AUC: {result.Metrics.AreaUnderRocCurve:P2}");
        }

        // Entrenamiento final del modelo usando todos los datos
        Console.WriteLine("Training final model...");
        var model = pipeline.Fit(data);

        // Guardar el modelo
        Console.WriteLine("Saving model...");
        context.Model.Save(model, data.Schema, "model.zip");

        // Carga del modelo
        Console.WriteLine("Loading model...");
        var loadedModel = context.Model.Load("model.zip", out var schema);

        var predictionEngine = context.Model.CreatePredictionEngine<CustomerData, CustomerPrediction>(loadedModel);

        // Predicción
        Console.WriteLine("Making prediction...");
        var newCustomer = new CustomerData { Age = 28, Salary = 55000 };
        var prediction = predictionEngine.Predict(newCustomer);

        Console.WriteLine($"Customer - Age = {newCustomer.Age} - Salary = {newCustomer.Salary}");
        Console.WriteLine($"Prediction: {(prediction.Purchase ? "Will Purchase" : "Will Not Purchase")}");
    }
}
