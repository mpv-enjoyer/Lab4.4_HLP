using System;

CustomStringDeque deque = new("HeadValue");
string? input = " ";
Console.WriteLine("search addbegin addend rmbegin rmend rmelement print exit");
while (true)
{
    Console.Write("> ");
    input = Console.ReadLine();
    if (input == null) continue;
    string[] split = input.Split();
    string command = split[0];
    string argument = split.Length > 1 ? split[1] : "";
    switch (command)
    {
        case "search":
            List<int> output = deque.Search(argument);
            for (int i = 0; i < output.Count; i++)
            {
                Console.Write($"{output[i]} ");
            }
            Console.WriteLine();
            break;
        case "addbegin":
            deque.AddBegin(argument);
            break;
        case "addend":
            deque.AddEnd(argument);
            break;
        case "rmbegin":
            deque.RemoveBegin();
            break;
        case "rmend":
            deque.RemoveEnd();
            break;
        case "rmelement":
            deque.Remove(argument);
            break;
        case "print":
            deque.Print();
            break;
        case "exit":
            Console.WriteLine("bye");
            return;
    }
}
