using Microsoft.ML.Data;

namespace MLNetPOC;
public class CustomerData
{
    [LoadColumn(0)]
    public float Age { get; set; }

    [LoadColumn(1)]
    public float Salary { get; set; }

    [LoadColumn(2)]
    public bool Purchase { get; set; }
}
