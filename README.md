# MLNetPOC

Se utiliza la biblioteca ML.NET para entrenar un modelo de machine learning que predice si un cliente realizará una compra (representada por la variable Purchase) basándose en su edad (Age) y salario (Salary).

### Paso 1: Configuración del Proyecto

Crear un nuevo proyecto de consola en .NET:

```bash
dotnet new console -n MLNetPOC
cd MLNetPOC
```

### Paso 2: Instalar el paquete ML.NET:

```bash
dotnet add package Microsoft.ML
```

Se prueba con un cliente de muestra, de 28 años de edad, con un salario de 55000.  

La predicción con el cliente otorgado es que No Compra:

```Loading data...  
Defining pipeline...  
Cross-validating model...  
Fold: 0, Accuracy: 49,97 %, AUC: 50,03 %  
Fold: 1, Accuracy: 49,97 %, AUC: 49,90 %  
Fold: 2, Accuracy: 50,06 %, AUC: 50,07 %  
Fold: 3, Accuracy: 49,86 %, AUC: 49,93 %  
Fold: 4, Accuracy: 50,23 %, AUC: 50,06 %  
Training final model...  
Saving model...  
Loading model...  
Making prediction...  
Prediction: Will Not Purchase 
```



