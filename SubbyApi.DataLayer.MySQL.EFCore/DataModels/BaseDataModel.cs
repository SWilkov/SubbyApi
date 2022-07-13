using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubbyApi.DataLayer.MySQL.EFCore.DataModels
{
  public class BaseDataModel
  {
    [Column("id")]
    [Key]
    public int Id { get; set; }
  }
}
