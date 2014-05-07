using HvadSagdiHann.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

  //ég er bara að prófa að breyta StudentRepo Verkefninu og búa til movie repo
namespace HvadSagdiHannSolutin.Models
{
	/// <summary>
	/// This class takes care of interacting with the datastore. Currently, we are just
	/// using an in-memory list of students, but we will change this class later
	/// so it will use a database instead.
	/// </summary>
	public class MovieRepository
	{
		// Note: don't let the "static" keyword fool you, this is just here
		// so we can emulate a database! Variables should otherwise never
		// be static!
		private static List<Movie> m_movie = new List<Movie>();

		/// <summary>
		/// Returns a list of all students.
		/// </summary>
		/// <returns></returns>
		public List<Student> GetAllStudents()
		{
			if (m_students.Count == 0)
			{
				m_students.Add(new Student { ID = 1, Name = "Andri Björn Ólafsson", Email = "andrio10@ru.is", DateOfBirth = new DateTime(1986, 2, 10) });
				m_students.Add(new Student { ID = 2, Name = "Andri Víðisson", Email = "andriv10@ru.is", DateOfBirth = new DateTime(1986, 12, 4) });
				m_students.Add(new Student { ID = 3, Name = "Arelíus Sveinn Arelíusarson", Email = "arelius10@ru.is", DateOfBirth = new DateTime(1975, 12, 6) });
				m_students.Add(new Student { ID = 4, Name = "Arnar Atli Sigurgíslason", Email = "arnaras10@ru.is", DateOfBirth = new DateTime(1989, 5, 16) });
				m_students.Add(new Student { ID = 5, Name = "Arnfríður Ingvarsdóttir", Email = "arnfridur09@ru.is", DateOfBirth = new DateTime(1985, 5, 27) });
				m_students.Add(new Student { ID = 6, Name = "Arnþór Ágústsson", Email = "arnthor09@ru.is", DateOfBirth = new DateTime(1979, 2, 15) });
				m_students.Add(new Student { ID = 7, Name = "Axel Axelsson", Email = "axel10@ru.is", DateOfBirth = new DateTime(1989, 6, 3) });
				m_students.Add(new Student { ID = 8, Name = "Axel Gauti Guðmundsson", Email = "axelg10@ru.is", DateOfBirth = new DateTime(1990, 7, 17) });
				m_students.Add(new Student { ID = 9, Name = "Axel Örn Sigurðsson", Email = "axels10@ru.is", DateOfBirth = new DateTime(1989, 6, 26) });
				m_students.Add(new Student { ID = 9, Name = "Ágúst Stefánsson", Email = "agusts09@ru.is", DateOfBirth = new DateTime(1989, 4, 29) });
			}

			return m_students;
		}

		/// <summary>
		/// Returns a single student with the given ID, or null if no such student can be found.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Student GetStudentById(int id)
		{
			var result = (from student in m_students
						  where student.ID == id
						  select student).SingleOrDefault();

			return result;
		}

		/// <summary>
		/// Adds a new student to the repository. Note that no validation is performed
		/// at this moment.
		/// </summary>
		/// <param name="s"></param>
		public void AddStudent(Student s)
		{
			// "Poor man's autoincrement" :-)
			s.ID = (from student in m_students
					select student.ID).Max() + 1;

			m_students.Add(s);
		}

		/// <summary>
		/// Updates an existing student.
		/// </summary>
		/// <param name="s"></param>
		public void UpdateStudent(Student s)
		{
			for (int i = 0; i < m_students.Count; i++)
			{
				if (s.ID == m_students[i].ID)
				{
					m_students[i] = s;
					break;
				}
			}
		}
	}
}