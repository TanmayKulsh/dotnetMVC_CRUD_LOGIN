const express=require("express");//import express
const mysql=require("mysql");//import mysql
const app=express();//obj creatd fr express 
//now crete obj for mysql and we r using it fr connection
const db=mysql.createConnection({
    host:'localhost',
    user:'root',
    password:'password',
    database:'shashankdb'//once database is created below we will connect it
}
    
);

db.connect((err)=>{
    if(err) throw err;
    console.log("mysql connected");
}
);

app.use(function (req, res, next) {
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
    res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
    res.setHeader('Access-Control-Allow-Credentials', true);
    next();
});

//to create database
// app.get('/createdb',(req,resp)=>{
//     let sql='CREATE DATABASE shashankdb';
//     db.query(sql,(err,result)=>{
//         if(err) throw err;
//         console.log(result);
//         resp.send(result);
//     });

// });

app.get('/createtb',(req,resp)=>{
    let sql='create table emp(empid int,name varchar(20),gender varchar(1))' ;
    db.query(sql,(err,result)=>{
        if(err) throw err;
        console.log(result);
        resp.send(result);
    });

});

app.get('/insertemp/:id/:name/:gender',(req,resp)=>{
    let sql=`insert into emp value(${req.params.id},${req.params.name},${req.params.gender})` ;
    db.query(sql,(err,result)=>{
        if(err) throw err;
        console.log(result);
        resp.send(result);
    });

});

app.get('/getallemp',(req,resp)=>{
    let sql='select * from emp' ;
    db.query(sql,(err,result)=>{
        if(err) throw err;
        console.log(result);
        resp.send(result);
    });

});

app.get('/getemp/:id',(req,resp)=>{
    let sql=`select * from emp where empid= ${req.params.id}` ;
    db.query(sql,(err,result)=>{
        if(err) throw err;
        console.log(result);
        resp.send(result);
    });

});
app.get('/updateemp/:id/:name',(req,resp)=>{
    let sql=`call updateemp(${req.params.id},${req.params.name})`;
    db.query(sql,(err,result)=>{
        if(err) throw err;
        console.log(result);
        resp.send(result);
    })

})

app.listen(4000,()=>{
    console.log("server is running");
});