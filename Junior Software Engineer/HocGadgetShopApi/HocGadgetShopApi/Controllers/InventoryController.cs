using HocGadgetShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace HocGadgetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> SaveInventoryData(InventoryRequestDto requestDto)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-66NHEU7\\SQLEXPRESS;Database=gadgetShop;User Id=sa;Password=punamo;"))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveInventoryData1", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", requestDto.ProductId);
                    command.Parameters.AddWithValue("@ProductName", requestDto.ProductName);
                    command.Parameters.AddWithValue("@AvailableQty", requestDto.AvailableQty);
                    command.Parameters.AddWithValue("@ReOrderPoint", requestDto.ReOrderPoint);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return Ok();
                }
            }
        }

        [HttpGet]

        public ActionResult GetInventoryData()
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = "Data Source=DESKTOP-66NHEU7\\SQLEXPRESS;Database=gadgetShop;User Id=sa;Password=punamo;"
            };

            SqlCommand command = new SqlCommand
            {
                CommandText = "sp_GetInventoryData",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            connection.Open();

            List<InventoryDto> response = new List<InventoryDto>();

            using (SqlDataReader sqlDataReader = command.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    InventoryDto inventoryDto = new InventoryDto();
                    inventoryDto.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
                    inventoryDto.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
                    inventoryDto.AvailableQty = Convert.ToInt32(sqlDataReader["AvailableQty"]);
                    inventoryDto.ReOrderPoint = Convert.ToInt32(sqlDataReader["ReOrderPoint"]);

                    response.Add(inventoryDto);
                }

            }

            connection.Close();


            return Ok(JsonConvert.SerializeObject(response));
        }
        

        [HttpDelete]

        public ActionResult DeleteInventoryData(int productId)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = "Data Source=DESKTOP-66NHEU7\\SQLEXPRESS;Database=gadgetShop;User Id=sa;Password=punamo;"
            };

            SqlCommand command = new SqlCommand
            {
                CommandText = "sp_DeleteInventoryDetails",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            connection.Open();

            command.Parameters.AddWithValue("@ProductId", productId);

            command.ExecuteNonQuery();
           

            connection.Close();


            return Ok();
        }


        [HttpPut]

        public ActionResult UpdateInventoryData(InventoryRequestDto inventoryRequest)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = "Data Source=DESKTOP-66NHEU7\\SQLEXPRESS;Database=gadgetShop;User Id=sa;Password=punamo;"
            };

            SqlCommand command = new SqlCommand
            {
                CommandText = "sp_UpdateInventoryData",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            connection.Open();

            command.Parameters.AddWithValue("@ProductId", inventoryRequest.ProductId);
            command.Parameters.AddWithValue("@ProductName", inventoryRequest.ProductName);
            command.Parameters.AddWithValue("@AvailableQty", inventoryRequest.AvailableQty);
            command.Parameters.AddWithValue("@ReOrderPoint", inventoryRequest.ReOrderPoint);

            command.ExecuteNonQuery();


            connection.Close();


            return Ok();
        }


    }
}

        
              

    

