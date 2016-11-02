class Person
{
    public int age;

    public Person(int initialAge)
    {
        if (initialAge < 0)
        {
            age = 0;
            Console.WriteLine("Age is not valid, setting age to 0.");
        }
        else
        {
            age = initialAge;
        }
    }

    public void amIOld()
    {
        if (age < 13)
        {
            Console.WriteLine("You are young.");
        }
        else if (age >= 18)
        {
            Console.WriteLine("You are old.");
        }
        else
        {
            Console.WriteLine("You are a teenager.");
        }
    }

    public void yearPasses()
    {
        age++;
    }
}