﻿namespace IdentitySystem.Domain;

public interface IHasDeleteOn
{
    bool        IsDeleted   { get;}
    DateTime?   DeleteOn    { get; }
}
