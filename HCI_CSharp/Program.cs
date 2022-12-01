// See https://aka.ms/new-console-template for more information

using System.Text;

FileStream fs = new("Human.csv", FileMode.Open, FileAccess.Read);
StreamReader sr = new(fs);
List<string> all_people = new List<string>();
List<string> people_training = new();
List<string> people_testing = new();
string? line;

Random random = new();
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

    all_people.Add(line);

    if (random.NextDouble() < .7)
    {
        people_training.Add(line);
    }
    else
    {
        people_testing.Add(line);
    }
}

#region code converters
Dictionary<string, int> ages_converted = new();
for (int i = 0; i < fields_uniqueVals["ages"].Count; i++)
{
    ages_converted.Add(fields_uniqueVals["ages"][i], i);
}
Dictionary<string, int> employ_status_converted = new();
for (int i = 0; i < fields_uniqueVals["employ_status"].Count; i++)
{
    employ_status_converted.Add(fields_uniqueVals["employ_status"][i], i);
}
Dictionary<string, int> income_converted = new();
for (int i = 0; i < fields_uniqueVals["income"].Count; i++)
{
    income_converted.Add(fields_uniqueVals["income"][i], i);
}
Dictionary<string, int> education_converted = new();
for (int i = 0; i < fields_uniqueVals["education"].Count; i++)
{
    education_converted.Add(fields_uniqueVals["education"][i], i);
}
Dictionary<string, int> number_converted = new();
for (int i = 0; i < fields_uniqueVals["number"].Count; i++)
{
    number_converted.Add(fields_uniqueVals["number"][i], i);
}
Dictionary<string, int> marital_status_converted = new();
for (int i = 0; i < fields_uniqueVals["marital_status"].Count; i++)
{
    marital_status_converted.Add(fields_uniqueVals["marital_status"][i], i);
}
Dictionary<string, int> work_field_converted = new();
for (int i = 0; i < fields_uniqueVals["work_field"].Count; i++)
{
    work_field_converted.Add(fields_uniqueVals["work_field"][i], i);
}
Dictionary<string, int> family_status_converted = new();
for (int i = 0; i < fields_uniqueVals["family_status"].Count; i++)
{
    family_status_converted.Add(fields_uniqueVals["family_status"][i], i);
}
Dictionary<string, int> race_converted = new();
for (int i = 0; i < fields_uniqueVals["race"].Count; i++)
{
    race_converted.Add(fields_uniqueVals["race"][i], i);
}
Dictionary<string, int> gender_converted = new();
for (int i = 0; i < fields_uniqueVals["gender"].Count; i++)
{
    gender_converted.Add(fields_uniqueVals["gender"][i], i);
}
Dictionary<string, int> num2_converted = new();
for (int i = 0; i < fields_uniqueVals["num2"].Count; i++)
{
    num2_converted.Add(fields_uniqueVals["num2"][i], i);
}
Dictionary<string, int> num3_converted = new();
for (int i = 0; i < fields_uniqueVals["num3"].Count; i++)
{
    num3_converted.Add(fields_uniqueVals["num3"][i], i);
}
Dictionary<string, int> num4_converted = new();
for (int i = 0; i < fields_uniqueVals["num4"].Count; i++)
{
    num4_converted.Add(fields_uniqueVals["num4"][i], i);
}
Dictionary<string, int> country_converted = new();
for (int i = 0; i < fields_uniqueVals["country"].Count; i++)
{
    country_converted.Add(fields_uniqueVals["country"][i], i);
}
Dictionary<string, int> target_converted = new();
for (int i = 0; i < fields_uniqueVals["target"].Count; i++)
{
    target_converted.Add(fields_uniqueVals["target"][i], i);
}
#endregion

StringBuilder sb = new();
sb.Clear();
for (int j = 0; j < people_training.Count; j++)
{
    string[] words = people_training[j].Split(',');
    words[0] = $"{ages_converted[words[0]]}";
    words[1] = $"{employ_status_converted[words[1]]}";
    words[2] = $"{income_converted[words[2]]}";
    words[3] = $"{education_converted[words[3]]}";
    words[4] = $"{number_converted[words[4]]}";
    words[5] = $"{marital_status_converted[words[5]]}";
    words[6] = $"{work_field_converted[words[6]]}";
    words[7] = $"{family_status_converted[words[7]]}";
    words[8] = $"{race_converted[words[8]]}";
    words[9] = $"{gender_converted[words[9]]}";
    words[10] = $"{num2_converted[words[10]]}";
    words[11] = $"{num3_converted[words[11]]}";
    words[12] = $"{num4_converted[words[12]]}";
    words[13] = $"{country_converted[words[13]]}";
    words[14] = $"{target_converted[words[14]]}";

    for (int i = 0; i < words.Length; i++)
    {
        if (i != 14)
            sb.Append(words[i] + ',');
        else
            sb.Append(words[i]);
    }
    people_training[j] = sb.ToString();
    sb.Clear();
}

#region occurrence lists
List<double> age_occurrence_under = new();
List<double> age_occurrence_over = new();
foreach (var item in ages_converted)
{
    age_occurrence_under.Add(0);
    age_occurrence_over.Add(0);
}
List<double> employ_status_occurrence_under = new();
List<double> employ_status_occurrence_over = new();
foreach (var item in employ_status_converted)
{
    employ_status_occurrence_under.Add(0);
    employ_status_occurrence_over.Add(0);
}
List<double> income_occurrence_under = new();
List<double> income_occurrence_over = new();
foreach (var item in income_converted)
{
    income_occurrence_under.Add(0);
    income_occurrence_over.Add(0);
}
List<double> education_occurrence_under = new();
List<double> education_occurrence_over = new();
foreach (var item in education_converted)
{
    education_occurrence_under.Add(0);
    education_occurrence_over.Add(0);
}
List<double> number_occurrence_under = new();
List<double> number_occurrence_over = new();
foreach (var item in number_converted)
{
    number_occurrence_under.Add(0);
    number_occurrence_over.Add(0);
}
List<double> marital_status_occurrence_under = new();
List<double> marital_status_occurrence_over = new();
foreach (var item in marital_status_converted)
{
    marital_status_occurrence_under.Add(0);
    marital_status_occurrence_over.Add(0);
}
List<double> work_field_occurrence_under = new();
List<double> work_field_occurrence_over = new();
foreach (var item in work_field_converted)
{
    work_field_occurrence_under.Add(0);
    work_field_occurrence_over.Add(0);
}
List<double> family_status_occurrence_under = new();
List<double> family_status_occurrence_over = new();
foreach (var item in family_status_converted)
{
    family_status_occurrence_under.Add(0);
    family_status_occurrence_over.Add(0);
}
List<double> race_occurrence_under = new();
List<double> race_occurrence_over = new();
foreach (var item in race_converted)
{
    race_occurrence_under.Add(0);
    race_occurrence_over.Add(0);
}
List<double> gender_occurrence_under = new();
List<double> gender_occurrence_over = new();
foreach (var item in gender_converted)
{
    gender_occurrence_under.Add(0);
    gender_occurrence_over.Add(0);
}
List<double> num2_occurrence_under = new();
List<double> num2_occurrence_over = new();
foreach (var item in num2_converted)
{
    num2_occurrence_under.Add(0);
    num2_occurrence_over.Add(0);
}
List<double> num3_occurrence_under = new();
List<double> num3_occurrence_over = new();
foreach (var item in num3_converted)
{
    num3_occurrence_under.Add(0);
    num3_occurrence_over.Add(0);
}
List<double> num4_occurrence_under = new();
List<double> num4_occurrence_over = new();
foreach (var item in num4_converted)
{
    num4_occurrence_under.Add(0);
    num4_occurrence_over.Add(0);
}
List<double> country_occurrence_under = new();
List<double> country_occurrence_over = new();
foreach (var item in country_converted)
{
    country_occurrence_under.Add(0);
    country_occurrence_over.Add(0);
}
List<double> target_occurrence = new();
foreach (var item in target_converted)
{
    target_occurrence.Add(0);
}
#endregion

for (int i = 0; i < people_training.Count; i++)
{
    string[] words = people_training[i].Split(',');
    if (words[14] == "0")
    {
        countOccur(age_occurrence_under, words[0]);
        countOccur(employ_status_occurrence_under, words[1]);
        countOccur(income_occurrence_under, words[2]);
        countOccur(education_occurrence_under, words[3]);
        countOccur(number_occurrence_under, words[4]);
        countOccur(marital_status_occurrence_under, words[5]);
        countOccur(work_field_occurrence_under, words[6]);
        countOccur(family_status_occurrence_under, words[7]);
        countOccur(race_occurrence_under, words[8]);
        countOccur(gender_occurrence_under, words[9]);
        countOccur(num2_occurrence_under, words[10]);
        countOccur(num3_occurrence_under, words[11]);
        countOccur(num4_occurrence_under, words[12]);
        countOccur(country_occurrence_under, words[13]);
    }
    else
    {
        countOccur(age_occurrence_over, words[0]);
        countOccur(employ_status_occurrence_over, words[1]);
        countOccur(income_occurrence_over, words[2]);
        countOccur(education_occurrence_over, words[3]);
        countOccur(number_occurrence_over, words[4]);
        countOccur(marital_status_occurrence_over, words[5]);
        countOccur(work_field_occurrence_over, words[6]);
        countOccur(family_status_occurrence_over, words[7]);
        countOccur(race_occurrence_over, words[8]);
        countOccur(gender_occurrence_over, words[9]);
        countOccur(num2_occurrence_over, words[10]);
        countOccur(num3_occurrence_over, words[11]);
        countOccur(num4_occurrence_over, words[12]);
        countOccur(country_occurrence_over, words[13]);
    }
    countOccur(target_occurrence, words[14]);
}

#region probability vars
List<double> prob_based_on_age_over = new();
List<double> prob_based_on_age_under = new(); foreach (var item in ages_converted) { prob_based_on_age_over.Add(0); prob_based_on_age_under.Add(0); }
List<double> prob_based_on_employ_over = new();
List<double> prob_based_on_employ_under = new(); foreach (var item in employ_status_converted) { prob_based_on_employ_over.Add(0); prob_based_on_employ_under.Add(0); }
List<double> prob_based_on_income_over = new();
List<double> prob_based_on_income_under = new(); foreach (var item in income_converted) { prob_based_on_income_over.Add(0); prob_based_on_income_under.Add(0); }
List<double> prob_based_on_edu_over = new();
List<double> prob_based_on_edu_under = new(); foreach (var item in education_converted) { prob_based_on_edu_over.Add(0); prob_based_on_edu_under.Add(0); }
List<double> prob_based_on_num_over = new();
List<double> prob_based_on_num_under = new(); foreach (var item in number_converted) { prob_based_on_num_over.Add(0); prob_based_on_num_under.Add(0); }
List<double> prob_based_on_marry_over = new();
List<double> prob_based_on_marry_under = new(); foreach (var item in marital_status_converted) { prob_based_on_marry_over.Add(0); prob_based_on_marry_under.Add(0); }
List<double> prob_based_on_work_over = new();
List<double> prob_based_on_work_under = new(); foreach (var item in work_field_converted) { prob_based_on_work_over.Add(0); prob_based_on_work_under.Add(0); }
List<double> prob_based_on_fam_over = new();
List<double> prob_based_on_fam_under = new(); foreach (var item in family_status_converted) { prob_based_on_fam_over.Add(0); prob_based_on_fam_under.Add(0); }
List<double> prob_based_on_race_over = new();
List<double> prob_based_on_race_under = new(); foreach (var item in race_converted) { prob_based_on_race_over.Add(0); prob_based_on_race_under.Add(0); }
List<double> prob_based_on_gender_over = new();
List<double> prob_based_on_gender_under = new(); foreach (var item in gender_converted) { prob_based_on_gender_over.Add(0); prob_based_on_gender_under.Add(0); }
List<double> prob_based_on_num2_over = new();
List<double> prob_based_on_num2_under = new(); foreach (var item in num2_converted) { prob_based_on_num2_over.Add(0); prob_based_on_num2_under.Add(0); }
List<double> prob_based_on_num3_over = new();
List<double> prob_based_on_num3_under = new(); foreach (var item in num3_converted) { prob_based_on_num3_over.Add(0); prob_based_on_num3_under.Add(0); }
List<double> prob_based_on_num4_over = new();
List<double> prob_based_on_num4_under = new(); foreach (var item in num4_converted) { prob_based_on_num4_over.Add(0); prob_based_on_num4_under.Add(0); }
List<double> prob_based_on_country_over = new();
List<double> prob_based_on_country_under = new(); foreach (var item in country_converted) { prob_based_on_country_over.Add(0); prob_based_on_country_under.Add(0); }


for (int i = 0; i < age_occurrence_under.Count; i++)
{
    prob_based_on_age_under[i] = age_occurrence_under[i] / target_occurrence[0];
    prob_based_on_age_over[i] = age_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < employ_status_occurrence_under.Count; i++)
{
    prob_based_on_employ_under[i] = employ_status_occurrence_under[i] / target_occurrence[0];
    prob_based_on_employ_over[i] = employ_status_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < income_occurrence_under.Count; i++)
{
    prob_based_on_income_under[i] = income_occurrence_under[i] / target_occurrence[0];
    prob_based_on_income_over[i] = income_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < education_occurrence_under.Count; i++)
{
    prob_based_on_edu_under[i] = education_occurrence_under[i] / target_occurrence[0];
    prob_based_on_edu_over[i] = education_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < number_occurrence_under.Count; i++)
{
    prob_based_on_num_under[i] = number_occurrence_under[i] / target_occurrence[0];
    prob_based_on_num_over[i] = number_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < marital_status_occurrence_under.Count; i++)
{
    prob_based_on_marry_under[i] = marital_status_occurrence_under[i] / target_occurrence[0];
    prob_based_on_marry_over[i] = marital_status_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < work_field_occurrence_under.Count; i++)
{
    prob_based_on_work_under[i] = work_field_occurrence_under[i] / target_occurrence[0];
    prob_based_on_work_over[i] = work_field_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < family_status_occurrence_under.Count; i++)
{
    prob_based_on_fam_under[i] = family_status_occurrence_under[i] / target_occurrence[0];
    prob_based_on_fam_over[i] = family_status_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < race_occurrence_under.Count; i++)
{
    prob_based_on_race_under[i] = race_occurrence_under[i] / target_occurrence[0];
    prob_based_on_race_over[i] = race_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < gender_occurrence_under.Count; i++)
{
    prob_based_on_gender_under[i] = gender_occurrence_under[i] / target_occurrence[0];
    prob_based_on_gender_over[i] = gender_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < num2_occurrence_under.Count; i++)
{
    prob_based_on_num2_under[i] = num2_occurrence_under[i] / target_occurrence[0];
    prob_based_on_num2_over[i] = num2_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < num3_occurrence_under.Count; i++)
{
    prob_based_on_num3_under[i] = num3_occurrence_under[i] / target_occurrence[0];
    prob_based_on_num3_over[i] = num3_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < num4_occurrence_under.Count; i++)
{
    prob_based_on_num4_under[i] = num4_occurrence_under[i] / target_occurrence[0];
    prob_based_on_num4_over[i] = num4_occurrence_over[i] / target_occurrence[1];
}
for (int i = 0; i < country_occurrence_under.Count; i++)
{
    prob_based_on_country_under[i] = country_occurrence_under[i] / target_occurrence[0];
    prob_based_on_country_over[i] = country_occurrence_over[i] / target_occurrence[1];
}
#endregion

for (int j = 0; j < people_testing.Count; j++)
{
    string[] words = people_testing[j].Split(',');
    words[0] = $"{ages_converted[words[0]]}";
    words[1] = $"{employ_status_converted[words[1]]}";
    words[2] = $"{income_converted[words[2]]}";
    words[3] = $"{education_converted[words[3]]}";
    words[4] = $"{number_converted[words[4]]}";
    words[5] = $"{marital_status_converted[words[5]]}";
    words[6] = $"{work_field_converted[words[6]]}";
    words[7] = $"{family_status_converted[words[7]]}";
    words[8] = $"{race_converted[words[8]]}";
    words[9] = $"{gender_converted[words[9]]}";
    words[10] = $"{num2_converted[words[10]]}";
    words[11] = $"{num3_converted[words[11]]}";
    words[12] = $"{num4_converted[words[12]]}";
    words[13] = $"{country_converted[words[13]]}";
    words[14] = $"{target_converted[words[14]]}";

    for (int i = 0; i < words.Length; i++)
    {
        if (i != 14)
            sb.Append(words[i] + ',');
        else
            sb.Append(words[i]);
    }
    people_testing[j] = sb.ToString();
    sb.Clear();
}

/********************************************************/
/********************************************************/
/********************************************************/
/********************************************************/
/********************************************************/

#region reset occur counts
//just using "over" cause we only need one and to save mem, maybe
for(int i = 0; i < ages_converted.Count; i++)
{
    age_occurrence_over[i] = 0;
}
for (int i = 0; i < employ_status_converted.Count; i++)
{
    employ_status_occurrence_over[i] = 0;
}
for (int i = 0; i < income_converted.Count; i++)
{
    income_occurrence_over[i] = 0;
}
for (int i = 0; i < education_converted.Count; i++)
{
    education_occurrence_over[i] = 0;
}
for (int i = 0; i < number_converted.Count; i++)
{
    number_occurrence_over[i] = 0;
}
for (int i = 0; i < marital_status_converted.Count; i++)
{
    marital_status_occurrence_over[i] = 0;
}
for (int i = 0; i < work_field_converted.Count; i++)
{
    work_field_occurrence_over[i] = 0;
}
for (int i = 0; i < family_status_converted.Count; i++)
{
    family_status_occurrence_over[i] = 0;
}
for (int i = 0; i < race_converted.Count; i++)
{
    race_occurrence_over[i] = 0;
}
for (int i = 0; i < gender_converted.Count; i++)
{
    gender_occurrence_over[i] = 0;
}
for (int i = 0; i < num2_converted.Count; i++)
{
    num2_occurrence_over[i] = 0;
}
for (int i = 0; i < num3_converted.Count; i++)
{
    num3_occurrence_over[i] = 0;
}
for (int i = 0; i < num4_converted.Count; i++)
{
    num4_occurrence_over[i] = 0;
}
for (int i = 0; i < country_converted.Count; i++)
{
    country_occurrence_over[i] = 0;
}
#endregion

//count occurrences in testing batch
for (int i = 0; i < people_testing.Count; i++)
{
    string[] words = people_testing[i].Split(',');
        countOccur(age_occurrence_over, words[0]);
        countOccur(employ_status_occurrence_over, words[1]);
        countOccur(income_occurrence_over, words[2]);
        countOccur(education_occurrence_over, words[3]);
        countOccur(number_occurrence_over, words[4]);
        countOccur(marital_status_occurrence_over, words[5]);
        countOccur(work_field_occurrence_over, words[6]);
        countOccur(family_status_occurrence_over, words[7]);
        countOccur(race_occurrence_over, words[8]);
        countOccur(gender_occurrence_over, words[9]);
        countOccur(num2_occurrence_over, words[10]);
        countOccur(num3_occurrence_over, words[11]);
        countOccur(num4_occurrence_over, words[12]);
        countOccur(country_occurrence_over, words[13]);
}

double total = -1d / (double)people_testing.Count;
double sum_under, sum_over, temp_over, temp_under;
double acc=0;

//Calculate Entropy!!!
for (int i = 0; i < people_testing.Count; i++)
{
    string[] words = people_testing[i].Split(',');
    sum_under = age_occurrence_over[int.Parse(words[0])] * checkCalc(Math.Log2(prob_based_on_age_under[int.Parse(words[0])]))
            + employ_status_occurrence_over[int.Parse(words[1])] * checkCalc(Math.Log2(prob_based_on_employ_under[int.Parse(words[1])]))
            + income_occurrence_over[int.Parse(words[2])]  * checkCalc(Math.Log2(prob_based_on_income_under[int.Parse(words[2])]))
            + education_occurrence_over[int.Parse(words[3])] * checkCalc(Math.Log2(prob_based_on_edu_under[int.Parse(words[3])]))
            + number_occurrence_over[int.Parse(words[4])] * checkCalc(Math.Log2(prob_based_on_num_under[int.Parse(words[4])]))
            + marital_status_occurrence_over[int.Parse(words[5])] * checkCalc(Math.Log2(prob_based_on_marry_under[int.Parse(words[5])]))
            + work_field_occurrence_over[int.Parse(words[6])] * checkCalc(Math.Log2(prob_based_on_work_under[int.Parse(words[6])]))
            + family_status_occurrence_over[int.Parse(words[7])] * checkCalc(Math.Log2(prob_based_on_fam_under[int.Parse(words[7])]))
            + race_occurrence_over[int.Parse(words[8])] * checkCalc(Math.Log2(prob_based_on_race_under[int.Parse(words[8])]))
            + gender_occurrence_over[int.Parse(words[9])] * checkCalc(Math.Log2(prob_based_on_gender_under[int.Parse(words[9])]))
            + num2_occurrence_over[int.Parse(words[10])] * checkCalc(Math.Log2(prob_based_on_num2_under[int.Parse(words[10])]))
            + num3_occurrence_over[int.Parse(words[11])] * checkCalc(Math.Log2(prob_based_on_num3_under[int.Parse(words[11])]))
            + num4_occurrence_over[int.Parse(words[12])] * checkCalc(Math.Log2(prob_based_on_num4_under[int.Parse(words[12])]))
            + country_occurrence_over[int.Parse(words[13])] * checkCalc(Math.Log2(prob_based_on_country_under[int.Parse(words[13])]));

    sum_over = age_occurrence_over[int.Parse(words[0])] * checkCalc(Math.Log2(prob_based_on_age_over[int.Parse(words[0])]))
            + employ_status_occurrence_over[int.Parse(words[1])] * checkCalc(Math.Log2(prob_based_on_employ_over[int.Parse(words[1])]))
            + income_occurrence_over[int.Parse(words[2])]  * checkCalc(Math.Log2(prob_based_on_income_over[int.Parse(words[2])]))
            + education_occurrence_over[int.Parse(words[3])] * checkCalc(Math.Log2(prob_based_on_edu_over[int.Parse(words[3])]))
            + number_occurrence_over[int.Parse(words[4])] * checkCalc(Math.Log2(prob_based_on_num_over[int.Parse(words[4])]))
            + marital_status_occurrence_over[int.Parse(words[5])] * checkCalc(Math.Log2(prob_based_on_marry_over[int.Parse(words[5])]))
            + work_field_occurrence_over[int.Parse(words[6])] * checkCalc(Math.Log2(prob_based_on_work_over[int.Parse(words[6])]))
            + family_status_occurrence_over[int.Parse(words[7])] * checkCalc(Math.Log2(prob_based_on_fam_over[int.Parse(words[7])]))
            + race_occurrence_over[int.Parse(words[8])] * checkCalc(Math.Log2(prob_based_on_race_over[int.Parse(words[8])]))
            + gender_occurrence_over[int.Parse(words[9])] * checkCalc(Math.Log2(prob_based_on_gender_over[int.Parse(words[9])]))
            + num2_occurrence_over[int.Parse(words[10])] * checkCalc(Math.Log2(prob_based_on_num2_over[int.Parse(words[10])]))
            + num3_occurrence_over[int.Parse(words[11])] * checkCalc(Math.Log2(prob_based_on_num3_over[int.Parse(words[11])]))
            + num4_occurrence_over[int.Parse(words[12])] * checkCalc(Math.Log2(prob_based_on_num4_over[int.Parse(words[12])]))
            + country_occurrence_over[int.Parse(words[13])] * checkCalc(Math.Log2(prob_based_on_country_over[int.Parse(words[13])]));

    temp_over = sum_over * total;
    temp_under = sum_under * total;
    if(temp_under < temp_over)
    {
        if (words[14] == "0")
            acc++;
    }
    else
    {
        if (words[14] == "1")
            acc++;
    }
}

acc = acc / people_testing.Count;

Console.WriteLine(acc);





//some functions
void pop_unique(string line)
{
    string[] words = line.Split(',');
    for (int i = 0; i < words.Length; i++)
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

void countOccur(List<double> occurrance, string target)
{
    occurrance[int.Parse(target)]++;
}

double checkCalc(double ans)
{
    if (double.IsNegativeInfinity(ans))
        ans = -5;
    else if (double.IsPositiveInfinity(ans))
        ans = 5;

    return ans;
}