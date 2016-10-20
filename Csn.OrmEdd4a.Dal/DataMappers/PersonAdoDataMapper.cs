namespace Csn.OrmEdd4a.Dal.DataMappers
{
    using Csn.OrmEdd4a.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class PersonAdoDataMapper : IDataMapper<Person>
    {
        private readonly IDbConnection _connection;

        private readonly string _connectionString;

        // ToDo concider removing this constructor
        public PersonAdoDataMapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public PersonAdoDataMapper(IDbConnection connection)
        {
            _connection = connection;
        }
        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            using (_connection)
            {
                try
                {
                    #region Preparation can be outside of try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"SELECT * FROM [Persons]";
                    #endregion

                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            persons.Add(Hydrate(reader));
                        }
                    }
                }
                catch (Exception e)
                {
                    // Log 
                    throw e;
                }
            }
            return persons;
        }

        public Person Get(int id)
        {
            Person person = new Person();
            using (_connection)
            {
                try
                {
                    #region Preparation can be outside of try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"SELECT * FROM [Persons] WHERE ID = @id";

                    IDataParameter param = command.CreateParameter();
                    param.ParameterName = "@id";
                    param.Value = id;
                    command.Parameters.Add(param);
                    #endregion

                    _connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        person = Hydrate(reader);
                    }
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
            }
            return person;
        }

        private Person Hydrate(IDataReader reader)
        {
            Person person = new Person();
            person.Id = (int)reader["ID"];
            person.Name = (string)reader["FirstName"];
            person.FamilyName = (string)reader["FamilyName"];
            person.BirthDate = (DateTime)reader["BirthDate"];
            person.Address = (string)reader["Address"];
            return person;
        }

        public int GetNextId()
        {
            throw new NotImplementedException();
        }

        public void Insert(Person entity)
        {
            using(_connection)
            {
                try
                {
                    #region Can be outside try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"INSERT INTO [Persons] 
                        ([FirstName],[FamilyName],[BirthDate],[Address]) VALUES 
                        (@Name,@FamilyName,@BirthDate,@Address)";
                    Extract(entity, command);
                    #endregion

                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
            }
        }

        public void Update(Person entity)
        {
            using (_connection)
            {
                try
                {
                    #region Can be outside try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"UPDATE [Persons] 
                        [ID]= @Id, 
                        [FirstName] = @Name,
                        [FamilyName] = @FamilyName,
                        [BirthDate] = @BirthDate,
                        [Address] = @Address 
                        WHERE ID = @Id";
                    Extract(entity, command);
                    #endregion

                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
            }
        }

        private void Extract(Person entity, IDbCommand command)
        {
            IDataParameter param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = entity.Id;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = entity.Name;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@FamilyName";
            param.Value = entity.FamilyName;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@BirthDate";
            param.Value = entity.BirthDate;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = entity.Address;
            command.Parameters.Add(param);
        }

        public void Delete(int id)
        {
            using (_connection)
            {
                try
                {
                    #region Can be outside try
                    IDbCommand command = _connection.CreateCommand();
                    command.Connection = _connection;
                    command.CommandText = @"DELETE FROM [Persons] WHERE ID = @Id";
                    IDataParameter param = command.CreateParameter();
                    param.ParameterName = "@Id";
                    param.Value = id;
                    command.Parameters.Add(param);
                    #endregion

                    _connection.Open();
                    //Perform DB operation here i.e. any CRUD operation 
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // Log
                    throw e;
                }
            }
        }
    }
}
