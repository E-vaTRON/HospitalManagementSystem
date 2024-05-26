namespace IdentitySystem.Application;

public record ServiceError( string ServiceName = "",
                            string MethodName = "",
                            string ConsumerName = "",
                            string ErrorMessage = "",
                            string ErrorCode = "",
                            string? SuggestionMessage = null,
                            DateTime EventOccuredAt = default!);