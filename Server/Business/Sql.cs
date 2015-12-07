namespace Server.Business
{
    /// <summary>
    /// 所有业务涉及到的sql语句
    /// </summary>
    /// <remarks>层需要加密、加壳</remarks>
    internal class Sql
    {
        /// <summary>
        /// 创建数据库
        /// </summary>
        public const string CreateDB = @"
                                        USE [master]
                                        GO
                                        CREATE DATABASE [{0}] ON 
                                        ( FILENAME = N'{1}\{0}.mdf' ),
                                        ( FILENAME = N'{1}\{0}_log.ldf' )
                                         FOR ATTACH
                                        GO";

        ///备份和还原数据库：
        ///http://blog.csdn.net/liuhelong/article/details/3335687

        // <summary>
        /// 初始化表（清空表内容，Truncate）
        /// </summary>
        /// <remarks>如果是delete {tablename}方式删除表数据，需要重置自增键-----> DBCC checkident('{0}', RESEED, 1)</remarks>
        public const string InitialiseTable = @"TRUNCATE TABLE {0}";

        /// <summary>
        /// 表、视图、存储过程
        /// </summary>
        /// <remarks>标量值函数 type='FN' | 表值函数 type='TF'</remarks>
        public const string GetDBTableS = @"SELECT name AS Item1, [sysobjects].[type] AS Item2 FROM [sysobjects] 
                                              WHERE [sysobjects].[type]='U' or [sysobjects].[type]='V' or [sysobjects].[type]='P'
                                              ORDER BY 
                                              CASE WHEN  [sysobjects].[type]='U' THEN 0 WHEN  [sysobjects].[type]='V' THEN 1 ELSE 2 END , name";
        /// <summary>
        /// 表信息
        /// </summary>
        public const string GetTableInfo = @"
            SELECT    
         --       tablename                      = case when a.colorder=1 then d.name else '' end
         -- ,     tabledescription               = case when a.colorder=1 then isnull(f.value,'') else '' end
         -- ,     colorder                       = a.colorder
          /*,*/   name                           = a.name
            ,     isindex                        = case when COLUMNPROPERTY( a.id, a.name, 'IsIdentity')=1 then 1 else 0 end
            ,     iskey                          = case when exists(
                                                             SELECT 1 FROM sysobjects where 
                                                                 xtype='PK' and 
                                                                 parent_obj=a.id and 
                                                                 name in (
                                                                             SELECT name FROM sysindexes WHERE indid in(
                                                                                 SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid
                                                                             )
                                                                         )
                                                             ) then 1 else 0 end
            ,     [type]                         = b.name
         -- ,     typelength                     = a.length
            ,     length                         = COLUMNPROPERTY(a.id,a.name,'PRECISION')
         -- ,     digits                         = isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0)
            ,     [isnull]                       = case when a.isnullable=1 then 1 else 0 end
            ,     defaultvalue                   = isnull(e.text,'')
            ,     description                    = isnull(g.[value],'')
            FROM  syscolumns                     a                   
            left  join  systypes                 b  on  a.xusertype=b.xusertype
            inner join  sysobjects               d  on  a.id=d.id and d.xtype='U' and d.name<>'dtproperties'
            left  join  syscomments              e  on  a.cdefault=e.id 
            left  join  sys.extended_properties  g  on  a.id=G.major_id and a.colid=g.minor_id 
            left  join  sys.extended_properties  f  on  d.id=f.major_id and f.minor_id=0
            where   d.name='{0}'
            order by  a.id,a.colorder
            ";

        /// <summary>
        /// 用户登录
        /// </summary>
        public static readonly string UserLogin = "SELECT * FROM [SysUser] WHERE UserName=@UserName;";


        //...


    }
}