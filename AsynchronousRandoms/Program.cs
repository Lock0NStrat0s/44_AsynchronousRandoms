namespace AsynchronousRandoms;

class Program
{
    static async Task Main(string[] args)
    {
        string? input;
        do
        {
            Console.Write("Enter Word to start (blank to exit): ");
            input = Console.ReadLine();
            HandleMethod(input);

        } while (input != "");
    }

    static async Task HandleMethod(string? input)
    {
        DateTime start = DateTime.Now;

        int attempts = await RandomlyRecreateAsync(input);
        Console.WriteLine($"\n\n\nWord: {input} has {attempts} attempts");


        DateTime end = DateTime.Now;
        TimeSpan timeElapsed = end - start;
        Console.WriteLine($"Total time: {timeElapsed.TotalSeconds}");
    }

    static int RandomlyRecreate(string word)
    {
        Random random = new Random();
        int attempts = 0;
        string newWord;

        do
        {
            newWord = "";

            while (newWord.Length < word.Length)
            {
                char temp = (char)('a' + random.Next(26));
                newWord += temp;
            }

            //Console.WriteLine(newWord);

            attempts++;
        } while (newWord != word);


        return attempts;
    }

    static Task<int> RandomlyRecreateAsync(string word)
    {
        return Task.Run(() => RandomlyRecreate(word));
    }
}