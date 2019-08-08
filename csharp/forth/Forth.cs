using System;
using Sprache;
using System.Collections.Generic;
using System.Linq;
public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        Parser<string> tokenItem =  
            from t in Parse.CharExcept(' ').Many().Text()
            from trailing in Parse.WhiteSpace.Many()
            select t;
        Parser<string> word = 
            from t in Parse.CharExcept(' ').Many().Text()
            select t;
        Parser<IEnumerable<string>> instruction = tokenItem.XMany().End();
        Stack<string> instructionStack = null; 
        Stack<int> processedStack = null;
        string retVal = "";
        Dictionary<string, List<string>> redefCommands = new Dictionary<string, List<string>>();
        for (int i=0; i < instructions.Length; i++) 
        {
            if (instructions[i].Contains(':')) // process variable line
            {
                string[] commandList = instruction.Parse(instructions[i]).ToArray();
                ParseDefinitions(ref redefCommands, commandList);
                continue;
            }
            instructionStack = new Stack<string>();
            processedStack = new Stack<int>();
            string[] line = instruction.Parse(instructions[i]).ToArray();
            foreach (var token in line.Reverse())
                instructionStack.Push(token);
            while (instructionStack.Where(s => !IsInt(s)).Count() > 0 )
            {
                if (IsInt(instructionStack.Peek()))
                {
                    processedStack.Push(int.Parse(instructionStack.Pop()));
                }
                else // operator
                {
                    string tmpInst = instructionStack.Pop().ToUpper();
                    if (redefCommands.Keys.Contains(tmpInst)) 
                    {
                        foreach (var v in redefCommands[tmpInst])
                            instructionStack.Push(v);
                    }
                    else 
                        ProcessInstruction(ref processedStack, tmpInst);
                }
            }
        }
        if (instructionStack.Where(s => !IsInt(s)).Count() == 0) // no instructions - just print
            for (int i=0; i < instructionStack.Count(); i++)
                processedStack.Push(int.Parse(instructionStack.ElementAt(i)));
        for (int i=processedStack.Count()-1; i >= 0; i--)
        {
            retVal += $"{processedStack.ElementAt(i)}";
            retVal += i > 0 ? " " : "";
        }
        return retVal;
    }

    private static bool IsInt(string s)
    {
        return int.TryParse(s, out int tmpInt);
    }

    private static void ProcessInstruction(ref Stack<int> varStack, string instruction)
    {
        int tmpInt1;
        int tmpInt2;
        int t;

        switch (instruction.ToUpper())
        {
            case "+":
                if (varStack.Count < 2)
                    throw new InvalidOperationException();
                tmpInt2 = varStack.Pop();
                tmpInt1 = varStack.Pop();
                t = tmpInt1 + tmpInt2;
                varStack.Push(t);
                break;
            case "-":
                if (varStack.Count < 2)
                    throw new InvalidOperationException();
                tmpInt2 = varStack.Pop();
                tmpInt1 = varStack.Pop();
                t = tmpInt1 - tmpInt2;
                varStack.Push(t);
                break;
            case "*":
                if (varStack.Count < 2)
                    throw new InvalidOperationException();
                tmpInt2 = varStack.Pop();
                tmpInt1 = varStack.Pop();
                t = tmpInt1 * tmpInt2;
                varStack.Push(t);
                break;
            case "/":
                if (varStack.Count < 2)
                    throw new InvalidOperationException();
                tmpInt2 = varStack.Pop();
                tmpInt1 = varStack.Pop();
                if (tmpInt2 == 0)
                    throw new InvalidOperationException();
                t = tmpInt1 / tmpInt2;
                varStack.Push(t);
                break;
            case "DUP":
                if (varStack.Count < 1)
                    throw new InvalidOperationException();
                varStack.Push(varStack.Peek());
                break;
            case "SWAP":
                if (varStack.Count < 2)
                    throw new InvalidOperationException();
                tmpInt1 = varStack.Pop();
                tmpInt2 = varStack.Pop();
                varStack.Push(tmpInt1);
                varStack.Push(tmpInt2);
                break;
            case "DROP":
                if (varStack.Count < 1)
                    throw new InvalidOperationException();
                varStack.Pop();
                break;
            case "OVER":
                if (varStack.Count < 2)
                    throw new InvalidOperationException();
                tmpInt1 = varStack.Pop();
                tmpInt2 = varStack.Pop();
                varStack.Push(tmpInt2);
                varStack.Push(tmpInt1);
                varStack.Push(tmpInt2);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    private static void ParseDefinitions(ref Dictionary<string, List<string>> commands, string[] words)
    {
        List<string> oldList = new List<string>();
        if (words[0] != ":" || IsInt(words[1]))
            throw new InvalidOperationException();
        string nameStr = words[1].ToUpper();
        if (words.Where(s => s.ToUpper() == nameStr).Count() > 0 && commands.Keys.Contains(nameStr))
            oldList.AddRange(commands[nameStr]);
        if (!commands.Keys.Contains(nameStr))
            commands.Add(nameStr, new List<string>());
        else 
        {
            commands[nameStr] = new List<string>();
        }
        for (int i=words.Length-2; i >= 2; i--)
        {
            string s = words[i].ToUpper();
            if (commands.Keys.Contains(s))
                if (s == nameStr)
                    commands[nameStr].AddRange(oldList);
                else
                    commands[nameStr].AddRange(commands[s]);
            else 
            {
                    commands[nameStr].Add(s);
            }
        }
    }
}