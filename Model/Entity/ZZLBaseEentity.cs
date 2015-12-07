namespace Model.Entity
{
    /// <summary>
    /// 数据库实体基类
    /// </summary>
    [System.Serializable]
    public class ZZLBaseEentity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
    }
}