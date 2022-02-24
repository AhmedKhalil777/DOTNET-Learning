// See https://aka.ms/new-console-template for more information
using Ardalis.GuardClauses;

TryAndWriteLine(() => Net6GuardingMyParmatersNoNull(null));
TryAndWriteLine(() => Net6GuardingMyParmatersNoNull("Ahmed"));
TryAndWriteLine(() => NetBefore6GuardingMyParmatersNoNull(null));
TryAndWriteLine(() => ArdalisGuardFromDefaults(DateTime.MinValue));
TryAndWriteLine(() => ArdalisGuardFromDefaults(0));
TryAndWriteLine(() => ArdalisGuardFromDefaults(default(string)));
TryAndWriteLine(() => ArdalisGuardFromZero(0));
TryAndWriteLine(() => ArdalisGuardFromNullOrEmpty(null));
TryAndWriteLine(() => ArdalisGuardFromNullOrEmpty(new List<int> { }));
TryAndWriteLine(() => ArdalisGuardFromOutOfSqlDateRange(DateTime.MaxValue));


static void TryAndWriteLine(Action evaluate)
{
    try
    {
        evaluate();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


/// <summary>
/// .Net 6 Guarding fron nulls
/// </summary>
static void Net6GuardingMyParmatersNoNull(string param)
{
    ArgumentNullException.ThrowIfNull(param);
}

/// <summary>
/// .Net before version 6
/// </summary>
static void NetBefore6GuardingMyParmatersNoNull(string param)
{
    param = param ?? throw new ArgumentNullException(nameof(param));
}

static  void ArdalisGuardFromNulls(string param)
{
    param = Guard.Against.Null(param);
}

static void ArdalisGuardFromNullOrEmpty(IEnumerable<int> listParam)
{
    listParam = Guard.Against.NullOrEmpty(listParam, nameof(listParam), "The List of params are empty or null");
}

static void ArdalisGuardFromZero(int param)
{
    param = Guard.Against.Zero(param, nameof(param));
}

static void ArdalisGuardFromDefaults<T>(T param)
{
    param = Guard.Against.Default(param, nameof(param));
}


static void ArdalisGuardFromOutOfSqlDateRange(DateTime param)
{
    param = Guard.Against.OutOfSQLDateRange(param, nameof(param));
}
