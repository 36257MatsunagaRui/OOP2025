namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
        }
    }

    class GreetingMorning {
        public string GetMessage() => "おはよう";
    }

    class GreetingAfternoon {
        public string GetMessage() => "こんにちは";
    }

    class GreetingEvening {
        public string GetMessage() => "こんばんは";
    }
}
