using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a infix String (+,-,*,/,^,a to z only):");
        String str = Console.ReadLine();
        char []infix= str.ToCharArray();
        if (!isValid(infix))
        {
            Console.WriteLine("You have entered Invalid Character");
        }
        else
        {
            postFix(infix);
        }
        Console.ReadKey();
    }
    static Boolean isValid(char []infix)
    {
            for(int i=0;i<infix.Length;i++)
            {
                char ch = infix[i];
                if (!isChar(ch) && ch != '+' && ch != '-' && ch != '*' && ch != '/' && ch != '^' && ch != '(' && ch != ')')
                {
                    Console.WriteLine(ch + " is not allowed");
                    return false;
                }
            }
        return true;
    }
    static void print(char []postfix,int length)
    {
        for(int i=0;i<=length;i++)
        {
            Console.Write(postfix[i]);
        }
    }
    static void postFix (char []infix)
    {
        Stack stack = new Stack(infix.Length);
        char[] postfix = new char[infix.Length];
        int j = 0;
        Console.WriteLine("Scan\t\tStack\t\tPostfix");
        for (int i=0;i<infix.Length;i++)
        {
            if (isChar(infix[i]))
            {
                postfix[j] = infix[i];
                j++;
            }
            else
            {
                if(infix[i]==')')
                {
                    while(stack.peep()!='(')
                    {
                        postfix[j] = stack.pop();
                        j++;
                    }
                    stack.pop();
                }
                else if(infix[i]=='(')
                {
                    stack.push(infix[i]);
                }
                else if ((prcd(stack.peep()))<prcd(infix[i]))
                {
                    stack.push(infix[i]);
                }                
                else if((prcd(stack.peep())) >= prcd(infix[i]))
                {
                    char c = stack.pop();
                    postfix[j] = c;
                    j++;
                    stack.push(infix[i]);
                }
            }
            Console.Write(infix[i] + "\t\t");
            stack.print();
            print(postfix, j - 1);
            Console.Write("\n");
        }
        while (!stack.isEmpty())
        {
            postfix[j] = stack.pop();
            j++;
            Console.Write("\t\t");
            stack.print();
            print(postfix, j - 1);
            Console.Write("\n");
        }
        Console.WriteLine("Postfix String:");
        for(int i=0;i<postfix.Length;i++)
        {
            Console.Write(postfix[i]);
        }
    }
    static int prcd(char ch)
    {
        if (ch == '(' || ch == ')')
            return 1;
        else if (ch == '+' || ch == '-')
            return 2;
        else if (ch == '*' || ch == '/')
            return 3;
        else if (ch == '^')
            return 4;
        return 0;
    }
    static Boolean isChar(char ch)
    {
        if(ch >= 'a' && ch <= 'z')
        {
            return true;
        }
        else if (ch >= 'A' && ch <= 'Z')
        {
            return true;
        }
        return false;
    }
}
public class Stack
{
    char []array=null;
    int top = -1;
    public Stack(int size)
    {
       array = new char[size];
    }
    public Boolean isEmpty()
    {
        if (top == -1)
        {
            return true;
        }
        return false;
    }
    public char peep()  
    {
        if (!isEmpty())
        {
            return array[top];   
        }
        return 'Z';
    }
    public void push(char ch)
    {
        top++;
        array[top] = ch;
    }
    public char pop()
    {
        if (!isEmpty())
        {
            char ch = array[top];
            top--;
            return ch;
        }
        return 'Z';
    }
    public void print()
    {
        for(int i=0;i<= top;i++)
        {
            Console.Write(array[i]);
        }
        Console.Write("\t\t");
    }
}