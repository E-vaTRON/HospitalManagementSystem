﻿namespace HospitalManagementSystem.Domain;

public static class DeviceInventoryExtensions
{
    #region [ Private Methods ]
    private static DeviceInventory AddAnalysisTest(this DeviceInventory deviceInventory, AnalysisTest analysisTest)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(analysisTest));

        if (deviceInventory.AnalysisTests.Any(x => x.Id == analysisTest.Id))
        {
            return deviceInventory;
        }

        analysisTest.DeviceInventoryId = deviceInventory.Id;
        analysisTest.DeviceInventory = deviceInventory;
        deviceInventory.AnalysisTests.Add(analysisTest);
        return deviceInventory;
    }
    #endregion

    #region [ Public Methods ]
    public static DeviceInventory AddAnalysisTest(this DeviceInventory deviceInventory)
    {
        return deviceInventory.AddAnalysisTest(AnalysisTestFactory.Create());
    }

    public static DeviceInventory AddAnalysisTest(this DeviceInventory deviceInventory, string doctorComment, string resultSummary, string specificMeasurements, string userId, string technicianSignature)
    {
        return deviceInventory.AddAnalysisTest(AnalysisTestFactory.Create(doctorComment, resultSummary, specificMeasurements, userId, technicianSignature));
    }

    public static DeviceInventory AddAnalysisTest(this DeviceInventory deviceInventory, string resultSummary, string specificMeasurements, string userId, string technicianSignature)
    {
        return deviceInventory.AddAnalysisTest(AnalysisTestFactory.Create(resultSummary, specificMeasurements, userId, technicianSignature));
    }

    public static DeviceInventory RemoveRelated(this DeviceInventory deviceInventory)
    {
        deviceInventory.Storage = null!;
        deviceInventory.MedicalDevice = null!;
        deviceInventory.AnalysisTests.Clear();
        return deviceInventory;
    }
    #endregion
}
