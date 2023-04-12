using System;

namespace Builder;

internal class Program
{

    //    Builder Pattern, karmaşık nesnelerin oluşturulmasını adım adım ve daha düzenli bir şekilde gerçekleştirmeye yardımcı olan bir creational tasarım kalıbıdır.
    //    Bu kalıp, nesne oluşturmayı yöneten bir "director" ve nesneleri adım adım oluşturan bir "builder" arasında işbirliği yaparak çalışır.

    //Builder Pattern'ın avantajları şunlardır:

    //Nesne oluşturma sürecini adım adım yönetir.
    //Karmaşık nesnelerin oluşturulmasını daha düzenli ve okunabilir hale getirir.
    //Director ve Builder sınıfları arasında işbirliği yaparak, kodun modülerliğini ve esnekliğini artırır.




//    Bu örnekte, `Resume` nesnelerini adım adım oluşturan `ResumeBuilder` ve bu süreci yöneten `ResumeDirector` sınıflarını kullanarak Builder Pattern'i uyguladık. Bu sayede, karmaşık ve farklı tipteki özgeçmişlerin oluşturulmasını daha düzenli ve modüler hale getirdik.

//Eğer Builder Pattern kullanmazsanız, özgeçmiş oluşturma sürecinde, her adımı ve kombinasyonu ayrı ayrı yönetmek ve nesne oluşturma sürecini düzenlemek zorlaşır.Bu durum, kodun daha karmaşık ve yönetilmesi güç hale gelmesine yol açabilir. Builder Pattern, nesne oluşturma süreçlerini yönetmek ve düzenlemek için daha düzenli ve esnek bir çözüm sunar.


    static void Main(string[] args)
    {
        IResumeBuilder builder = new ResumeBuilder();
        ResumeDirector director = new ResumeDirector();

        List<string> skills = new List<string> { "C#", "Java", "Python" };
        List<string> experiences = new List<string> { "Software Developer at XYZ", "Software Engineer at ABC" };

        Resume myResume = director.Build(builder, "John Doe", "johnDoe@email.com", "Software Developer with 5 years of experience", skills, experiences);
        Console.WriteLine("Name: " + myResume.Name);
        Console.WriteLine("Email: " + myResume.Email);
        Console.WriteLine("Summary: " + myResume.Summary);
        Console.WriteLine("Skills: " + string.Join(", ", myResume.Skills));
        Console.WriteLine("Experiences: " + string.Join(", ", myResume.Experiences));
    }

    public class Resume
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Experiences { get; set; }
    }

    public interface IResumeBuilder
    {
        void SetName(string name);
        void SetEmail(string email);
        void SetSummary(string summary);
        void AddSkill(string skill);
        void AddExperience(string experience);
        Resume GetResume();
    }

    public class ResumeBuilder : IResumeBuilder
    {
        private Resume _resume = new Resume();

        public void SetName(string name) => _resume.Name = name;
        public void SetEmail(string email) => _resume.Email = email;
        public void SetSummary(string summary) => _resume.Summary = summary;

        public void AddSkill(string skill)
        {
            if (_resume.Skills == null)
            {
                _resume.Skills = new List<string>();
            }
            _resume.Skills.Add(skill);
        }

        public void AddExperience(string experience)
        {
            if (_resume.Experiences == null)
            {
                _resume.Experiences = new List<string>();
            }
            _resume.Experiences.Add(experience);
        }

        public Resume GetResume()
        {
            Resume result = _resume;
            _resume = new Resume();
            return result;
        }
    }

    public class ResumeDirector
    {
        public Resume Build(IResumeBuilder builder, string name, string email, string summary, List<string> skills, List<string> experiences)
        {
            builder.SetName(name);
            builder.SetEmail(email);
            builder.SetSummary(summary);

            foreach (var skill in skills)
            {
                builder.AddSkill(skill);
            }

            foreach (var experience in experiences)
            {
                builder.AddExperience(experience);
            }

            return builder.GetResume();
        }
    }
}