namespace IdentitySystem.Application;

public record ServiceSuccess( string ServiceName = "",
                              string MethodName = "",
                              string ConsumerName = "",
                              object? AttachedData = default!,
                              string SuccessMessage = "",
                              string SuccessCode = "",
                              DateTime EventOccuredAt = default!);