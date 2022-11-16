// See https://aka.ms/new-console-template for more information

FileStream fs = new("Human.csv", FileMode.Open, FileAccess.Read);
StreamReader sr = new(fs);
List<string> people_training = new();
List<string> people_testing = new();
string? line;
int count = 0;


Dictionary<string, List<string>> fields_uniqueVals = new Dictionary<string, List<string>>();
string[] fields = { "ages", "employ_status", "income", "education", "number", "marital_status",
    "work_field", "family_status", "race", "gender", "num2", "num3", "num4", "country", "target" };

#region initial dictionaries
List<string> uniqueVals1 = new();
List<string> uniqueVals2 = new();
List<string> uniqueVals3 = new();
List<string> uniqueVals4 = new();
List<string> uniqueVals5 = new();
List<string> uniqueVals6 = new();
List<string> uniqueVals7 = new();
List<string> uniqueVals8 = new();
List<string> uniqueVals9 = new();
List<string> uniqueVals10 = new();
List<string> uniqueVals11 = new();
List<string> uniqueVals12 = new();
List<string> uniqueVals13 = new();
List<string> uniqueVals14 = new();
List<string> uniqueVals15 = new();
fields_uniqueVals.Add("ages", uniqueVals1);
fields_uniqueVals.Add("employ_status", uniqueVals2);
fields_uniqueVals.Add("income", uniqueVals3);
fields_uniqueVals.Add("education", uniqueVals4);
fields_uniqueVals.Add("number", uniqueVals5);
fields_uniqueVals.Add("marital_status", uniqueVals6);
fields_uniqueVals.Add("work_field", uniqueVals7);
fields_uniqueVals.Add("family_status", uniqueVals8);
fields_uniqueVals.Add("race", uniqueVals9);
fields_uniqueVals.Add("gender", uniqueVals10);
fields_uniqueVals.Add("num2", uniqueVals11);
fields_uniqueVals.Add("num3", uniqueVals12);
fields_uniqueVals.Add("num4", uniqueVals13);
fields_uniqueVals.Add("country", uniqueVals14);
fields_uniqueVals.Add("target", uniqueVals15);
#endregion

while ((line = sr.ReadLine()) != null)
{
    //skip lines with '?' and first line
    if (line.Contains('?') || line.Contains("x1"))
        continue;

    //populate unique dictionary
    pop_unique(line);

    if (count < 7)
    {
        people_training.Add(line);
        count++;
    }
    else
    {
        people_testing.Add(line);
        count = 0;
    }
}

#region code converters
Dictionary<string, int> ages_converted = new();
for(int i = 0; i < fields_uniqueVals["ages"].Count; i++)
{
    ages_converted.Add(fields_uniqueVals["ages"][i], i);
}
Dictionary<string, int> employ_status_converted = new();
for(int i = 0; i < fields_uniqueVals["employ_status"].Count; i++)
{
    employ_status_converted.Add(fields_uniqueVals["employ_status"][i], i);
}
Dictionary<string, int> income_converted = new();
for(int i = 0; i < fields_uniqueVals["income"].Count; i++)
{
    income_converted.Add(fields_uniqueVals["income"][i], i);
}
Dictionary<string, int> education_converted = new();
for(int i = 0; i < fields_uniqueVals["education"].Count; i++)
{
    education_converted.Add(fields_uniqueVals["education"][i], i);
}
Dictionary<string, int> number_converted = new();
for(int i = 0; i < fields_uniqueVals["number"].Count; i++)
{
    number_converted.Add(fields_uniqueVals["number"][i], i);
}
Dictionary<string, int> marital_status_converted = new();
for(int i = 0; i < fields_uniqueVals["marital_status"].Count; i++)
{
    marital_status_converted.Add(fields_uniqueVals["marital_status"][i], i);
}
Dictionary<string, int> work_field_converted = new();
for(int i = 0; i < fields_uniqueVals["work_field"].Count; i++)
{
    work_field_converted.Add(fields_uniqueVals["work_field"][i], i);
}
Dictionary<string, int> family_status_converted = new();
for(int i = 0; i < fields_uniqueVals["family_status"].Count; i++)
{
    family_status_converted.Add(fields_uniqueVals["family_status"][i], i);
}
Dictionary<string, int> race_converted = new();
for(int i = 0; i < fields_uniqueVals["race"].Count; i++)
{
    race_converted.Add(fields_uniqueVals["race"][i], i);
}
Dictionary<string, int> gender_converted = new();
for(int i = 0; i < fields_uniqueVals["gender"].Count; i++)
{
    gender_converted.Add(fields_uniqueVals["gender"][i], i);
}
Dictionary<string, int> num2_converted = new();
for(int i = 0; i < fields_uniqueVals["num2"].Count; i++)
{
    num2_converted.Add(fields_uniqueVals["num2"][i], i);
}
Dictionary<string, int> num3_converted = new();
for(int i = 0; i < fields_uniqueVals["num3"].Count; i++)
{
    num3_converted.Add(fields_uniqueVals["num3"][i], i);
}
Dictionary<string, int> num4_converted = new();
for(int i = 0; i < fields_uniqueVals["num4"].Count; i++)
{
    num4_converted.Add(fields_uniqueVals["num4"][i], i);
}
Dictionary<string, int> country_converted = new();
for(int i = 0; i < fields_uniqueVals["country"].Count; i++)
{
    country_converted.Add(fields_uniqueVals["country"][i], i);
}
Dictionary<string, int> target_converted = new();
for(int i = 0; i < fields_uniqueVals["target"].Count; i++)
{
    target_converted.Add(fields_uniqueVals["target"][i], i);
}
#endregion

return 0;

//for( int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"training line: {people_training[i]}\ntesting line: {people_testing[i]}\n\n");
//}

void pop_unique(string line)
{
    string[] words = line.Split(',');
    for(int i = 0; i < words.Length; i++)
    {
        //if the data has not been read before
        if (checkUnique(fields_uniqueVals[fields[i]], words[i]))
        {
            //example:
            //fields_uniqueVals["ages"].Add("25");
            fields_uniqueVals[fields[i]].Add(words[i]);
        }
    }
}

bool checkUnique(List<string> list, string target)
{
    if (list.Contains(target))
        //not unique
        return false;
    else
        //unique
        return true;
}