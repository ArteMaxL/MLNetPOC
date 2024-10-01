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
Fold: 0, Accuracy: 85,43 %, AUC: 88,58 %
Fold: 1, Accuracy: 85,25 %, AUC: 88,54 %
Fold: 2, Accuracy: 85,30 %, AUC: 88,49 %
Fold: 3, Accuracy: 85,57 %, AUC: 88,44 %
Fold: 4, Accuracy: 85,28 %, AUC: 88,34 %  
Training final model...  
Saving model...  
Loading model...  
Making prediction...  
Prediction: Will Not Purchase 
```



