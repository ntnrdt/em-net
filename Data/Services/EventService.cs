using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using MeetApp.Data.Entities;
using MeetApp.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MeetApp.Data.Services
{
    public class EventService : IEventService
    {
        private IConfiguration _config;

        public EventService(IConfiguration config) => _config = config;

        /// <summary>
        /// Returns all Events from the database.
        /// </summary>
        /// <returns></returns>
        public List<Event> Get()
        {
            var accounts = new List<Event>();

            try
            {
                using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                using var cmd = new SqlCommand("SelectEvents", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        accounts.Add(AutoMap(dataReader));

                connection.Close();
            }
            catch (Exception ex)
            {
                Debugger.Log(0, "Get", ex.Message);
            }

            return accounts;
        }

        /// <summary>
        /// Giving the Event Id, it will return its information from the Database.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <returns></returns>
        public Event Get(int? id)
        {
            if (id == null) return null;

            var account = new Event();

            try
            {
                using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                using var cmd = new SqlCommand("SelectEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                connection.Open();

                using (var dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        account = AutoMap(dataReader);

                connection.Close();
            }
            catch (Exception ex)
            {
                Debugger.Log(0, "Get", ex.Message);
            }

            return account;
        }

        /// <summary>
        /// Giving the Event model, creates it in the Database.
        /// </summary>
        /// <param name="model">Event data.</param>
        public void Create(Event model)
        {
            if (model == null) return;

            try
            {
                using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                using var cmd = new SqlCommand("InsertEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar)).Value = model.Title;
                cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar)).Value = model.Description;
                cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime)).Value = model.Date;
                cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)).Value = model.Price;
                cmd.Parameters.Add(new SqlParameter("@ImageUrl", SqlDbType.VarChar)).Value = model.ImageUrl;
                cmd.Parameters.Add(new SqlParameter("@OnlineUrl", SqlDbType.VarChar)).Value = model.OnlineUrl;
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar)).Value = model.Address;
                cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar)).Value = model.City;
                cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar)).Value = model.Country;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Debugger.Log(0, "Get", ex.Message);
            }
        }

        /// <summary>
        /// Giving the Event model, updates it in the Database.
        /// </summary>
        /// <param name="model">Event data.</param>
        public void Update(Event model)
        {
            if (model == null) return;

            try
            {
                using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                using var cmd = new SqlCommand("UpdateEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = model.Id;
                cmd.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar)).Value = model.Title;
                cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar)).Value = model.Description;
                cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime)).Value = model.Date;
                cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)).Value = model.Price;
                cmd.Parameters.Add(new SqlParameter("@ImageUrl", SqlDbType.VarChar)).Value = model.ImageUrl;
                cmd.Parameters.Add(new SqlParameter("@OnlineUrl", SqlDbType.VarChar)).Value = model.OnlineUrl;
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar)).Value = model.Address;
                cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar)).Value = model.City;
                cmd.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar)).Value = model.Country;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Debugger.Log(0, "Get", ex.Message);
            }
        }

        /// <summary>
        /// Giving the Event Id, it will delete its information from the Database.
        /// </summary>
        /// <param name="id">Event Id.</param>
        public void Delete(int? id)
        {
            if (id == null) return;

            try
            {
                using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                using var cmd = new SqlCommand("DeleteEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Debugger.Log(0, "Get", ex.Message);
            }
        }

        /// <summary>
        /// Giving the SqlDataReader, it will map its information into a new Event model.
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private Event AutoMap(SqlDataReader dataReader)
        {
            return new Event()
            {
                Id = GetValue<int>(dataReader["Id"]),
                Title = GetValue<string>(dataReader["Title"]),
                Description = GetValue<string>(dataReader["Description"]),
                Date = GetValue<DateTime>(dataReader["Date"]),
                Price = GetValue<decimal>(dataReader["Price"]),
                ImageUrl = GetValue<string>(dataReader["ImageUrl"]),
                OnlineUrl = GetValue<string>(dataReader["OnlineUrl"]),
                Address = GetValue<string>(dataReader["Address"]),
                City = GetValue<string>(dataReader["City"]),
                Country = GetValue<string>(dataReader["Country"])
            };
        }

        /// <summary>
        /// Giving the expected return Type and the value from the DataReader.
        /// Tries to return the conversion.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private dynamic GetValue<T>(object value)
        {
            try
            {
                return (T)value;
            }
            catch
            {
                return null;
            }
        }
    }
}