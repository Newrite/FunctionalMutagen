# FunctionalMutagen

Functional wrapper for Mutagen.Bethesda library, check it here: https://github.com/Mutagen-Modding/Mutagen 

The library aims to improve the use of the mutagen from F#, because F# is not very user-friendly when using C# libraries. It also adds a bit of functional use of some of the methods now wrapped in functions.

###  Some script create DSL

Look this

```FSHarp
    Scripts.ScriptEntry.create "XP" [
      Scripts.ScriptProperty.float "XPStaticAmount" staticAmount
      Scripts.ScriptProperty.float "XPMultAmount" multAmount
    ]
```