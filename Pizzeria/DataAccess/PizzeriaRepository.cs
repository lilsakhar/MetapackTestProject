using Dapper;
using Pizzeria.bl.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pizzeria.DataAccess
{
    public class PizzeriaRepository
    {
        private readonly ConnectionFactory connectionFactory;

        public PizzeriaRepository(ConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public List<Kategoria> GetAllCategories()
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SearchText", "");

                return conn
                    .Query<Kategoria>("CategoryViewSearch", param, commandType: CommandType.StoredProcedure)
                    .ToList<Kategoria>();
            }
        }

        public List<Dania> FillDataGrid(string categoryName)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Category_name", categoryName.Trim());
                List<Dania> result = conn
                    .Query<Dania>("CategorySelect", param, commandType: CommandType.StoredProcedure).ToList<Dania>();

                return result;
            }
        }

        public void AddLine(int id)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID_dania", id);
                conn.Execute("SzczegolyAdd", param, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Returns picture byte array
        /// </summary>
        public byte[] GetPicture(int categoryId)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                return conn.ExecuteScalar<byte[]>(
                    "SELECT Picture FROM Kategoria WHERE ID_kategoria = @id",
                    new { id = categoryId }
                );
            }
        }

        public List<Dania> FillDataGridOrder()
        {
            using (var conn = connectionFactory.GetConnection())
            {
                return conn
                    .Query<Dania>("SzczegolySelect", commandType: CommandType.StoredProcedure)
                    .ToList<Dania>();
            }
        }

        public void ClearOrderLines(int id)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID_dania", id);
                conn.Execute("OrderLinesClear", param, commandType: CommandType.StoredProcedure);
            }
        }

        public string CalculateOrderSum()
        {
            using (var conn = connectionFactory.GetConnection())
            {
                String sql = @"SELECT IsNull(SUM(d.cena*l.ilosc),0)
			                     FROM Dania d INNER JOIN  OrderLines l ON l.ID_dania = d.ID_dania";
                return Convert.ToString(conn.ExecuteScalar<String>(sql));
            }
        }

        public void CreateOrder(
                             string name,
                             string surname,
                             string email,
                             string notes
                             )
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Imie", name);
                param.Add("@Nazwisko", surname);
                param.Add("@Email", email);
                param.Add("@Uwagi", notes);
                conn.Execute("ZamowienieAdd", param, commandType: CommandType.StoredProcedure);

            }
        }

        public List<Zamowienie> FillDataGridHistoryList()
        {
            using (var conn = connectionFactory.GetConnection())
            {
                List<Zamowienie> list = conn
                    .Query<Zamowienie>("HistoryGoraSelect", commandType: CommandType.StoredProcedure)
                    .ToList<Zamowienie>();
                return list;
            }
        }

        public List<Szczegoly> FillDataGridDetalsList(int id)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID_zamowienia", id);

                List<Szczegoly> list = conn
                    .Query<Szczegoly>("HistoryDolSelect", param, commandType: CommandType.StoredProcedure)
                    .ToList<Szczegoly>();
                return list;
            }
        }

        //Admin
        //Category
        #region Category

        public List<Kategoria> FillDataGridView(string txtSearch)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SearchText", txtSearch.Trim());
                List<Kategoria> list = conn
                    .Query<Kategoria>("CategoryViewSearch", param, commandType: CommandType.StoredProcedure)
                    .ToList<Kategoria>();
                return list;
            }
        }

        public void AddCategory(int id, string txtCategory)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID_kategoria", id);
                param.Add("@Nazwa_Kategoria", txtCategory);
                conn.Execute("[CategoryAddEdit]", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCategory(int id)
        {
            using (var conn = connectionFactory.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID_kategoria", id);
                conn.Execute("CategoryDeleteByID", param, commandType: CommandType.StoredProcedure);
            }
        }


        #endregion

    }
}
