using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static school_management_system.SchoolManagmentSystem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace school_management_system
{
    public partial class SchoolManagmentSystem : Form
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sjanr\\Desktop\\school management system\\SchoolManagmentSystem.mdf\";Integrated Security=True";
        private List<Student> students; // Declare the students list as a member variable
        private List<Teacher> teachers; // Declare the teachers list as a member variable
        private List<Course> courses; // Declare the courses list as a member variable

        public SchoolManagmentSystem()
        {
            InitializeComponent();
            students = new List<Student>();
            teachers = new List<Teacher>();
            courses = new List<Course>();

            // Add course options to the list box for student
            stuCourse_listBox.Items.AddRange(new string[] { "Programming Foundation", "Software Development", "Graphic Design" });

            // Add course options to the list box for teacher
            teCourse_listBox.Items.AddRange(new string[] { "Programming Foundation", "Software Development", "Graphic Design" });

            // Add department options to the list box for teacher
            teDepartment_listBox.Items.AddRange(new string[] { "Computer Science", "Graphic Design" });

            // Add course options to the list box for course
            coName_listBox.Items.AddRange(new string[] { "Programming Foundation", "Software Development", "Graphic Design" });

            // Add category options to the list box for course
            coCategory_listBox.Items.AddRange(new string[] { "Computer Science", "Graphic Design" });
        }

        // Student Managment
        public void stuManagment_label_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public class Student
        {
            public string StudentId { get; set; }
            public string StudentName { get; set; }
            public string Gender { get; set; }
            public string CourseEnrollment { get; set; }
            public string ContactNumber { get; set; }
            public string Address { get; set; }
        }

        private void stuID_label_Click(object sender, EventArgs e)
        {

        }

        private void stuID_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stuName_label_Click(object sender, EventArgs e)
        {

        }

        private void stuName_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stuGender_label_Click(object sender, EventArgs e)
        {

        }

        private void stuMale_rButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void stuFemale_rButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void stuCourse_label_Click(object sender, EventArgs e)
        {

        }

        private void stuCourse_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void stuContact_label_Click(object sender, EventArgs e)
        {

        }

        private void stuContact_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stuAddress_label_Click(object sender, EventArgs e)
        {

        }

        private void stuAddress_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stuAdd_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from the input controls
                string studentID = stuID_textBox.Text;
                string fullName = stuName_textBox.Text;
                string gender = stuMale_rButton.Checked ? "Male" : "Female";
                string courseEnrolled = stuCourse_listBox.SelectedItem?.ToString(); // Handle null selection
                string contactNumber = stuContact_textBox.Text;
                string address = stuAddress_textBox.Text;

                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(fullName) ||
                    string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(courseEnrolled) ||
                    string.IsNullOrWhiteSpace(contactNumber) || string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Please enter all fields.");
                    return; // Stop execution if any field is empty
                }

                // Create a new Student object
                Student newStudent = new Student
                {
                    StudentId = studentID,
                    StudentName = fullName,
                    Gender = gender,
                    CourseEnrollment = courseEnrolled,
                    ContactNumber = contactNumber,
                    Address = address
                };

                // Validate the contact number format
                if (!string.IsNullOrWhiteSpace(contactNumber) && !Regex.IsMatch(contactNumber, @"^\d{10}$"))
                {
                    MessageBox.Show("Please enter a 10-digit contact number.");
                    return;
                }

                // Add the new student to the students list
                students.Add(newStudent);

                MessageBox.Show("Student added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the student: {ex.Message}");
            }
        }

        private void stuClear_button_Click(object sender, EventArgs e)
        {
            // Clear all input controls
            stuID_textBox.Clear();
            stuName_textBox.Clear();
            stuMale_rButton.Checked = true;
            stuCourse_listBox.ClearSelected();
            stuContact_textBox.Clear();
            stuAddress_textBox.Clear();
        }

        private void stuSearch_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stuSearch_button_Click(object sender, EventArgs e)
        {
            string searchValue = stuSearch_textBox.Text;

            // Filter the students list based on the search value
            // Filter the students list based on the search value
            List<Student> filteredStudents = students
                .Where(s => s.StudentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            s.StudentId.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            // Convert the filteredStudents list to a DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StudentID");
            dataTable.Columns.Add("FullName");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("CourseEnrolled");
            dataTable.Columns.Add("ContactNumber");
            dataTable.Columns.Add("Address");

            foreach (Student student in filteredStudents)
            {
                dataTable.Rows.Add(student.StudentId, student.StudentName, student.Gender, student.CourseEnrollment,
                student.ContactNumber, student.Address);
            }

            // Display the search results in the DataGridView
            Student_DVG.DataSource = dataTable;
        }

        private void Student_DVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stuUpdate_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected student's ID from the DataGridView
                string studentID = Student_DVG.CurrentRow.Cells["StudentID"].Value.ToString();

                if (string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("Please select a student.");
                    return;
                }

                // Retrieve the updated values from the input controls
                string fullName = stuName_textBox.Text;
                string gender = stuMale_rButton.Checked ? "Male" : "Female";
                string courseEnrolled = stuCourse_listBox.SelectedItem.ToString();
                string contactNumber = stuContact_textBox.Text;
                string address = stuAddress_textBox.Text;

                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(courseEnrolled) ||
                    string.IsNullOrWhiteSpace(contactNumber) || string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Please enter all fields.");
                    return;
                }

                // Validate the contact number format
                if (!string.IsNullOrWhiteSpace(contactNumber) && !Regex.IsMatch(contactNumber, @"^\d{10}$"))
                {
                    MessageBox.Show("Please enter a 10-digit contact number.");
                    return;
                }

                // Find the student in the list
                Student student = students.FirstOrDefault(s => s.StudentId == studentID);

                if (student == null)
                {
                    MessageBox.Show("Student not found.");
                    return;
                }

                // Update the student's details in the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE StudentDetails SET [Student Name] = @FullName, Gender = @Gender, [Course Enrollment] = @CourseEnrolled, " +
                                   "[Contact Number] = @ContactNumber, Address = @Address WHERE [Student Id] = @StudentID";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@CourseEnrolled", courseEnrolled);
                    command.Parameters.AddWithValue("@ContactNumber", contactNumber);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Student updated successfully.");

                // Find the selected student in the students list
                Student selectedStudent = students.Find(s => s.StudentId == studentID);

                if (selectedStudent != null)
                {
                    // Update the student's details
                    selectedStudent.StudentName = stuName_textBox.Text;
                    selectedStudent.Gender = stuMale_rButton.Checked ? "Male" : "Female";
                    selectedStudent.CourseEnrollment = stuCourse_listBox.SelectedItem.ToString();
                    selectedStudent.ContactNumber = stuContact_textBox.Text;
                    selectedStudent.Address = stuAddress_textBox.Text;

                    MessageBox.Show("Student updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the student: {ex.Message}");
            }
        }

        private void stuDelete_button_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = Student_DVG.CurrentRow.Cells["StudentID"].Value.ToString();

                // Find the selected student in the students list
                Student selectedStudent = students.Find(s => s.StudentId == studentID);

                if (selectedStudent != null)
                {
                    // Remove the selected student from the students list
                    students.Remove(selectedStudent);

                    MessageBox.Show("Student deleted successfully.");

                    // Refresh the DataGridView after deleting the student
                    stuSearch_button_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Apologies, an error occurred while deleting the student: {ex.Message}");
            }
        }

        private void stuExit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Teacher Managment
        private void teManagment_label_Click(object sender, EventArgs e)
        {

        }
        public class Teacher
        {
            public string TeacherId { get; set; }
            public string TeacherName { get; set; }
            public string Gender { get; set; }
            public string Course { get; set; }
            public string Department { get; set; }
            public string ContactNumber { get; set; }
        }
        private void teID_label_Click(object sender, EventArgs e)
        {

        }

        private void teID_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void teName_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void teMale_rButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void teFemale_rButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void teCourse_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void teDepartment_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void teContact_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsTeacherIdUnique(string teacherId, bool excludeCurrentTeacher = false)
        {
            // Check if the ID is unique among existing teachers
            bool isUnique = !teachers.Any(t => t.TeacherId == teacherId);

            // Exclude the current teacher when updating
            if (excludeCurrentTeacher && !isUnique)
            {
                string currentTeacherId = Teacher_DGV.CurrentRow.Cells["TeacherID"].Value.ToString();
                isUnique = !teachers.Any(t => t.TeacherId == teacherId && t.TeacherId != currentTeacherId);
            }

            return isUnique;
        }

        private void teAdd_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from the input controls
                string teacherID = teID_textBox.Text;
                string fullName = teName_textBox.Text;
                string gender = teMale_rButton.Checked ? "Male" : "Female";
                string department = teDepartment_listBox.SelectedItem?.ToString(); // Handle null selection
                string contactNumber = teContact_textBox.Text;

                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(teacherID) || string.IsNullOrWhiteSpace(fullName) ||
                    string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(department))
                {
                    MessageBox.Show("Please enter all fields.");
                    return; // Stop execution if any field is empty
                }

                // Create a new Teacher object
                Teacher newTeacher = new Teacher
                {
                    TeacherId = teacherID,
                    TeacherName = fullName,
                    Gender = gender,
                    Department = department,
                    ContactNumber = contactNumber
                };

                // Validate the contact number format
                if (!string.IsNullOrWhiteSpace(contactNumber) && !Regex.IsMatch(contactNumber, @"^\d{10}$"))
                {
                    MessageBox.Show("Please enter a 10-digit contact number.");
                    return;
                }

                // Add the new teacher to the teachers list
                teachers.Add(newTeacher);

                // Insert the teacher into the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO TeacherDetails ([Teacher Id], [Teacher Name], Gender, Course, Department, [Contact Number]) " +
                                   "VALUES (@TeacherID, @FullName, @Gender, @Course, @Department, @ContactNumber)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Course", "");
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@ContactNumber", contactNumber);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Teacher added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add teacher.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the teacher: {ex.Message}");
            }
        }

        private void teClear_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear the input controls
                teID_textBox.Text = string.Empty;
                teName_textBox.Text = string.Empty;
                teMale_rButton.Checked = false;
                teFemale_rButton.Checked = false;
                teDepartment_listBox.ClearSelected();
                teContact_textBox.Text = string.Empty;

                // Clear the DataGridView
                Teacher_DGV.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clearing the fields: {ex.Message}");
            }
        }

        private void teSearch_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void teSearch_button_Click(object sender, EventArgs e)
        {
            try
            {
                string searchKeyword = teSearch_textBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchKeyword))
                {
                    MessageBox.Show("Please enter the teacher's name or ID.");
                    return;
                }

                // Search for teachers matching the search keyword
                List<Teacher> searchResults = teachers.Where(t => t.TeacherName.Contains(searchKeyword)).ToList();

                if (searchResults.Count == 0)
                {
                    MessageBox.Show("No teachers found.");
                    return;
                }

                // Display the search results in the DataGridView
                Teacher_DGV.DataSource = searchResults;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Apologies, an error occurred while searching for teachers: {ex.Message}");
            }
        }

        private void Teacher_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void teEdit_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected teacher's ID from the DataGridView
                string teacherID = Teacher_DGV.CurrentRow.Cells["TeacherID"].Value.ToString();

                if (string.IsNullOrEmpty(teacherID))
                {
                    MessageBox.Show("Please select a teacher.");
                    return;
                }

                // Retrieve the updated values from the input controls
                string fullName = teName_textBox.Text;
                string gender = teMale_rButton.Checked ? "Male" : "Female";
                string department = teDepartment_listBox.SelectedItem?.ToString(); // Handle null selection
                string contactNumber = teContact_textBox.Text;

                // Check if any field is empty
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(gender) ||
                    string.IsNullOrWhiteSpace(department))
                {
                    MessageBox.Show("Please enter all fields.");
                    return;
                }

                // Find the teacher in the list
                Teacher teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherID);

                if (teacher == null)
                {
                    MessageBox.Show("Teacher not found.");
                    return;
                }

                // Update the teacher's details in the list
                teacher.TeacherName = fullName;
                teacher.Gender = gender;
                teacher.Department = department;
                teacher.ContactNumber = contactNumber;

                // Validate the contact number format
                if (!string.IsNullOrWhiteSpace(contactNumber) && !Regex.IsMatch(contactNumber, @"^\d{10}$"))
                {
                    MessageBox.Show("Please enter a 10-digit contact number.");
                    return;
                }

                // Update the teacher's details in the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE TeacherDetails SET [Teacher Name] = @FullName, Gender = @Gender, " +
                                   "Department = @Department, [Contact Number] = @ContactNumber WHERE [Teacher Id] = @TeacherID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TeacherID", teacherID);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Course", "");
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@ContactNumber", contactNumber);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Teacher updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update teacher.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the teacher: {ex.Message}");
            }
        }

        private void teDelete_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected teacher's ID from the DataGridView
                string teacherID = Teacher_DGV.CurrentRow.Cells["TeacherID"].Value.ToString();

                if (string.IsNullOrEmpty(teacherID))
                {
                    MessageBox.Show("Please select a teacher.");
                    return;
                }

                // Find the teacher in the list
                Teacher teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherID);

                if (teacher == null)
                {
                    MessageBox.Show("Teacher not found.");
                    return;
                }

                // Remove the teacher from the list
                teachers.Remove(teacher);

                // Delete the teacher from the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM TeacherDetails WHERE [Teacher Id] = @TeacherID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TeacherID", teacherID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Teacher deleted successfully.");

                        // Remove the selected row from the DataGridView
                        Teacher_DGV.Rows.RemoveAt(Teacher_DGV.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete teacher.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Apologies, an error occurred while deleting the teacher: {ex.Message}");
            }
        }
        private void teExit_button_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        // Course Managment
        private void coManagment_label_Click(object sender, EventArgs e)
        {

        }

        // Course class to represent a course
        public class Course
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public string Category { get; set; }
        }

        // Class-level declarations
        //private List<Course> courses = new List<Course>();
        private List<Course> searchResults = new List<Course>();

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void coID_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void coName_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void coCategory_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void co_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Courses(object sender, EventArgs e)
        {
            // Load courses from the database into the courses list
            LoadCoursesFromDatabase();

            // Display all courses in the DataGridView
            DisplayAllCourses();
        }

        private void LoadCoursesFromDatabase()
        {
            try
            {
                // Establish a connection to the database
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sjanr\\Desktop\\school management system\\SchoolManagmentSystem.mdf\";Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve the course details from the CourseDetails table
                    string selectQuery = "SELECT [Course Id], [Course Name], [Category] FROM CourseDetails";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Course course = new Course
                                {
                                    CourseId = reader.GetInt32(0),
                                    CourseName = reader.GetString(1),
                                    Category = reader.GetString(2)
                                };

                                courses.Add(course);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading courses from the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void coAdd_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input data
                if (string.IsNullOrEmpty(coID_textBox.Text) || string.IsNullOrEmpty(coName_listBox.Text) ||
                    string.IsNullOrEmpty(coCategory_listBox.Text))
                {
                    MessageBox.Show("Please fill in all the course details.", "Incomplete Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int courseId;
                if (!int.TryParse(coID_textBox.Text, out courseId))
                {
                    MessageBox.Show("Invalid course ID. Please enter a valid numeric value.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if a course with the same ID already exists
                if (courses.Any(c => c.CourseId == courseId))
                {
                    MessageBox.Show("A course with the same ID already exists. Please enter a unique ID.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new course object
                Course course = new Course
                {
                    CourseId = courseId,
                    CourseName = coName_listBox.Text,
                    Category = coCategory_listBox.Text
                };

                // Add the course to the list
                courses.Add(course);

                // Add the course to the database table
                AddCourseToDatabase(course);

                // Clear the input fields
                ClearInputFields();

                // Display all courses in the DataGridView
                DisplayAllCourses(); // Add this line
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the course: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCourseToDatabase(Course course)
        {
            try
            {
                // Establish a connection to the database
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sjanr\\Desktop\\school management system\\SchoolManagmentSystem.mdf\";Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert the course details into the CourseDetails table
                    string insertQuery = "INSERT INTO CourseDetails ([Course Id], [Course Name], [Category]) VALUES (@ID, @Title, @Category)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", course.CourseId);
                        command.Parameters.AddWithValue("@Title", course.CourseName);
                        command.Parameters.AddWithValue("@Category", course.Category);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Course successfully added to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the course to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void coCleas_button_Click(object sender, EventArgs e)
        {
            // Clear the input fields
            ClearInputFields();
        }

        private void coSearch_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void coSearch_button_Click(object sender, EventArgs e)
        {
            // Validate input data
            if (string.IsNullOrEmpty(coSearch_textbox.Text))
            {
                MessageBox.Show("Please enter the ID or name.");
                return;
            }

            string keyword = coSearch_textbox.Text.ToLower();

            // Search for courses matching the keyword in the title or course ID
            searchResults = courses
                .Where(c => c.CourseName.ToLower().Contains(keyword) || c.CourseId.ToString().Contains(keyword))
                .ToList();

            // Display search results in the DataGridView
            Course_DGV.DataSource = searchResults;

            // Clear the input fields
            ClearInputFields();
        }

        private void Course_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void coEdit_button_Click(object sender, EventArgs e)
        {
            // Validate input data
            if (string.IsNullOrEmpty(coID_textBox.Text))
            {
                MessageBox.Show("Please enter a course ID to edit.");
                return;
            }

            int courseId;
            if (!int.TryParse(coID_textBox.Text, out courseId))
            {
                MessageBox.Show("Invalid course ID. Please enter a valid numeric value.");
                return;
            }

            // Find the course with the specified ID in the courses list
            Course course = courses.FirstOrDefault(c => c.CourseId == courseId);

            if (course == null)
            {
                MessageBox.Show("No course found with the specified ID.");
                return;
            }

            // Update the course details
            course.CourseName = coName_listBox.Text;
            course.Category = coCategory_listBox.Text;

            // Update the course in the database table
            UpdateCourseInDatabase(course);

            // Clear the input fields
            ClearInputFields();

            // Display all courses in the DataGridView
            DisplayAllCourses();
        }

        private void coDelete_button_Click(object sender, EventArgs e)
        {
            // Validate input data
            if (string.IsNullOrEmpty(coID_textBox.Text))
            {
                MessageBox.Show("Please enter a course ID to delete.");
                return;
            }

            int courseId;
            if (!int.TryParse(coID_textBox.Text, out courseId))
            {
                MessageBox.Show("Invalid course ID. Please enter a valid numeric value.");
                return;
            }

            // Find the course with the specified ID
            Course course = courses.FirstOrDefault(c => c.CourseId == courseId);

            if (course == null)
            {
                MessageBox.Show("No course found with the specified ID.");
                return;
            }

            // Remove the course from the list
            courses.Remove(course);

            // Delete the course from the database table
            DeleteCourseFromDatabase(course);

            // Clear the input fields
            ClearInputFields();

            // Display all courses in the DataGridView
            DisplayAllCourses();
        }

        private void UpdateCourseInDatabase(Course course)
        {
            // Establish a connection to the database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sjanr\\Desktop\\school management system\\SchoolManagmentSystem.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update the course details in the CourseDetails table
                string updateQuery = "UPDATE CourseDetails SET [Course Name] = @Title, [Category] = @Category WHERE [Course Id] = @ID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", course.CourseId);
                    command.Parameters.AddWithValue("@Title", course.CourseName);
                    command.Parameters.AddWithValue("@Category", course.Category);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void DeleteCourseFromDatabase(Course course)
        {
            // Establish a connection to the database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\sjanr\\Desktop\\school management system\\SchoolManagmentSystem.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Delete the course from the CourseDetails table
                string deleteQuery = "DELETE FROM CourseDetails WHERE [Course Id] = @ID";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", course.CourseId);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void DisplayAllCourses()
        {
            // Display all courses in the DataGridView
            Course_DGV.DataSource = courses;
        }


        private void ClearInputFields()
        {
            coID_textBox.Text = string.Empty;
            coName_listBox.SelectedIndex = -1;
            coCategory_listBox.SelectedIndex = -1;
        }

        private void coExit_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Close the application
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exiting the application: " + ex.Message);
            }
        }

        // Exit System Tab
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitTab_label_Click(object sender, EventArgs e)
        {

        }

        private void Yes_button_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private void No_button_Click(object sender, EventArgs e)
        {
            // Redirect to the Student Management tab
            TabControll.SelectedIndex = 0; // Assuming the Student Management tab index is 1
        }

        // Login Tab
        private void LoginStarted_label_Click(object sender, EventArgs e)
        {

        }

        private void LUsername_label_Click(object sender, EventArgs e)
        {

        }

        private void LUsername__tBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LPassword_label_Click(object sender, EventArgs e)
        {

        }

        private void LPassword_tBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LShowP_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on the checkbox state
            LPassword_tBox.UseSystemPasswordChar = !LShowP_checkBox.Checked;
        }

        private void LLogin_button_Click(object sender, EventArgs e)
        {
            string username = LUsername__tBox.Text;
            string password = LPassword_tBox.Text;

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter Username and Password!");
                return;
            }

            try
            {
                // Check if the provided credentials are valid
                if (ValidateCredentials(username, password))
                {
                    MessageBox.Show("Login Successful!");
                    // Proceed to the School Management System
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while validating credentials: " + ex.Message);
            }
        }

        private void LClear_button_Click(object sender, EventArgs e)
        {
            // Clear the textboxes
            LUsername__tBox.Clear(); // Username textbox
            LPassword_tBox.Clear(); // Password textbox
        }

        private void NohaveAccount_label_Click(object sender, EventArgs e)
        {
           
        }

        private void CreateAccount_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate to the SignUp tab
            SchoolManagmentSystem signUpForm = new SchoolManagmentSystem();
            signUpForm.Show();
            this.Hide(); 
        }

        private bool ValidateCredentials(string username, string password)
        {
            bool isValid = false;

            try
            {
                // Create a SQL connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create the SQL query
                    string query = "SELECT COUNT(*) FROM UserDetails WHERE Username = @Username AND Password = @Password";

                    // Create a SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the query and check the result
                        int count = (int)command.ExecuteScalar();
                        isValid = (count > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while validating credentials against the database.", ex);
            }

            return isValid;
        }

        // SignUp Tab
        private void SStarted_label_Click(object sender, EventArgs e)
        {

        }

        private void SUsername_Lable_Click(object sender, EventArgs e)
        {

        }

        private void SUsername_tBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SPassword_Lable_Click(object sender, EventArgs e)
        {

        }

        private void SPassword_tBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SConfirmP_label_Click(object sender, EventArgs e)
        {

        }

        private void SConfirmP_tBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SshowP_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on the checkbox state
            SPassword_tBox.UseSystemPasswordChar = !SshowP_checkBox.Checked;
            SConfirmP_tBox.UseSystemPasswordChar = !SshowP_checkBox.Checked;
        }
        private void SRegister_button_Click(object sender, EventArgs e)
        {
            string username = SUsername_tBox.Text;
            string password = SPassword_tBox.Text;
            string confirmPassword = SConfirmP_tBox.Text;

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please enter all required fields!");
                return;
            }

            // Check if the passwords match
            if (password == confirmPassword)
            {
                try
                {
                    // Save the user details to the database
                    SaveUserDetails(username, password);
                    MessageBox.Show("Registration Successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while saving user details: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
            }
        }

        private void SaveUserDetails(string username, string password)
        {
            try
            {
                // Create a SQL connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create the SQL query
                    string query = "INSERT INTO UserDetails (Username, Password) VALUES (@Username, @Password)";

                    // Create a SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while saving user details to the database.", ex);
            }
        }

        private void SClear_button_Click(object sender, EventArgs e)
        {
            // Clear the textboxes
            SUsername_tBox.Clear(); // Username textbox
            SPassword_tBox.Clear(); // Password textbox
            SConfirmP_tBox.Clear(); // Confirm Password textbox
        }

        private void haveAccount_label_Click(object sender, EventArgs e)
        {

        }

        private void BtoLogin_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Close the current tab
            this.Hide(); // Assuming the form is named "this"

            // Open the Login tab
            SchoolManagmentSystem loginForm = new SchoolManagmentSystem();
            loginForm.Show();
        }
    }
}
