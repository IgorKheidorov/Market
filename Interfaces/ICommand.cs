﻿namespace OOPSample.Interfaces;

internal interface ICommand
{
    string Execute();
    Task<string> ExecuteAsync();
    bool Undo();
}
