
namespace Task
{
    class ArgumentParser
    {
        public ParsedArgs Parse(string[] args)
        {
            var parsed = new ParsedArgs();
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if (arg.StartsWith("--"))
                {
                    parsed.AddSwitch(arg.Substring(2));
                }
                else if (arg.StartsWith("-"))
                {
                    var valIndex = i + 1;
                    if (valIndex >= args.Length)
                        throw new OptionMissingValueException(arg.Substring(1));
                    var val = args[valIndex];
                    i += 1;
                    parsed.AddOption(arg.Substring(1), val);
                }
                else
                {
                    parsed.AddArg(arg);
                }
            }
            return parsed;
        }
    }
}
