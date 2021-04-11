using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression;
            int a = 0, b = 0;
            Console.Write("İfadeyi giriniz:");
            expression = Console.ReadLine();
            Converter converter = new Converter();
            for (int i = 0; i < expression.Length; i++)
            {
                var result = expression[i];
                if (result == '*' || result == '/' || result == '+' || result == '-')
                {
                    a++;

                }
                else
                {
                    b++;
                }
            }
            if (b == a + 1)
            {
                String exp = expression;
                Console.WriteLine(converter.getInfix(exp));
            }
            else
            {
                Console.Write("Hatalı arttaki ifade");
            }

            Console.ReadLine();
        }

      
    }
    class Converter
    {

        static Boolean isOperand(char x)
        {
            return (x >= 'a' && x <= 'z') ||
                    (x >= 'A' && x <= 'Z');
        }


        public String getInfix(String exp)
        {
            _Stack s = new _Stack(250);

            for (int i = 0; i < exp.Length; i++)
            {
             
                if (isOperand(exp[i]))
                {
                    s.Push(exp[i] + "");
                }

                else
                {
                    String op1 = (String)s.Peek();
                    s.Pop();
                    String op2 = (String)s.Peek();
                    s.Pop();
                    s.Push("(" + op2 + exp[i] + op1 + ")");
                }
            }
            return (String)s.Peek();
        }
    }
        public interface IStack
        {
        void Push(object item);
        object Pop();
        object Peek();
        bool IsEmpty();
        int Top { get; set; }
        int Count();


    }
    public class _Stack : IStack
    {
        private object[] items;
        public int top = -1;
        public _Stack(int itemCount)
        {
            this.items = new object[itemCount];
        }

        public void Push(object item)
        {
            if (items.Length == Top + 1)
            {
                throw new Exception("Hata: Stack doldu... ");
            }
            items[++Top] = item;

        }

        public object Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Hata: Stack boş...");
            }
            Object temp = items[Top--];
            return temp;
        }
        public object Peek()
        {
            return items[Top];
        }
        public bool IsEmpty()
        {
            return Top == -1 ? true : false;
        }

        public int Count()
        {
            return items.Length;
        }

        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

    }
}
