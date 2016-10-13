﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewTest.Dao;
using Models;
using System.Data.SqlClient;
using SqlSugar;
namespace NewTest.Demos
{
    public class MyCost {public static Student2 p = new Student2() { id = 5, name = "张表", isOk = true };}
    //单元测试
    public class Test : IDemos
    {
        public Student2 Getp() {  return new Student2() { id = 4, name = "张表" , isOk=true};}
        public Student2 _p = new Student2() { id = 3, name = "张表", isOk = true };
        public void Init()
        {
            Student2 p = new Student2() { id = 2, name = "张表", isOk = true };
            Console.WriteLine("启动Test.Init");
            using (var db = SugarDao.GetInstance())
            {

                //解析拉姆达各种情况组合

                //基本
                var t1 = db.Queryable<Student>().Where(it => it.id == 1).ToList();
                var t2 = db.Queryable<Student>().Where(it => it.id == p.id).ToList();
                var t3 = db.Queryable<Student>().Where(it => it.id == _p.id).ToList();
                var t4 = db.Queryable<Student>().Where(it => it.id == Getp().id).ToList();
                var t5 = db.Queryable<Student>().Where(it => it.id == MyCost.p.id).ToList();


                //BOOL
                var t11 = db.Queryable<Student2>("Student").Where(it => it.isOk).ToList();
                var t21 = db.Queryable<Student2>("Student").Where(it => it.isOk==MyCost.p.isOk).ToList();
                var t31 = db.Queryable<Student2>("Student").Where(it => !it.isOk).ToList();
                var t41 = db.Queryable<Student2>("Student").Where(it => it.isOk==true).ToList();
                var t51 = db.Queryable<Student2>("Student").Where(it =>it.isOk==false).ToList();
                var t61 = db.Queryable<Student2>("Student").Where(it => it.isOk == _p.isOk).ToList();
                var t71 = db.Queryable<Student2>("Student").Where(it => !it.isOk&& !p.isOk==it.isOk).ToList();
                var t91 = db.Queryable<Student2>("Student").Where(it =>_p.isOk == false).ToList();
                var t81 = db.Queryable<Student>().Where(it => it.isOk==false).ToList();
                var t111 = db.Queryable<Student2>("Student").Where(it => it.isOk && false).ToList();


                //length
                var c1 = db.Queryable<Student>().Where(c => c.name.Length > 4).ToList();
                var c2 = db.Queryable<Student>().Where(c => c.name.Length > _p.name.Length).ToList();
                var c3 = db.Queryable<Student>().Where(c => c.name.Length > "aa".Length).ToList();
                var c4 = db.Queryable<Student>().Where(c => c.name.Length > Getp().id).ToList();


                //Equals
                var a1 = db.Queryable<Student>().Where(c => c.name.Equals(null)).ToList();
                var x = new InsertTest() { };
                var x1 = db.Queryable<Student>().Where(c => c.name.Equals(x.int1)).ToList();
                var a2 = db.Queryable<Student>().Where(c => c.name.Equals(p.name)).ToList();
                var a4 = db.Queryable<Student>().Where(c => c.name.Equals(Getp().name)).ToList();



                //Contains
                var s = db.Queryable<Student>().Where(c => c.name.Contains(null)).ToList();
                var s0 = new InsertTest() { };
                var s1 = db.Queryable<Student>().Where(c => c.name.Contains(x.v1)).ToList();
                var s3 = db.Queryable<Student>().Where(c => c.name.Contains(p.name)).ToList();
                var s4 = db.Queryable<Student>().Where(c => c.name.Contains(Getp().name)).ToList();


                var sss = db.Queryable<Student>().Where(c => p.name.Equals(c.name)).ToList();
                var xx = db.Queryable<Student>().Where(c => p.name.Contains(c.name)).ToList();
            }
        }
    }
}
