import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Service from "./Service.js";
const ViewData = () => {
const [emparr,setemparr]=useState([]);
const [flag,setFlag]=useState(false);
// const [username,setusername]=useState("");
useEffect(() => {
    Service.getallemp().then((response) => {
        setemparr(response.data);
        console.log(emparr);
        setFlag(true);


    })
        .catch((err) => { console.log("error occured", err) });

}, [flag]);

const renderList=()=>{
    return emparr.map((emp)=>{
        return <tr key={emp.empid}><td>{emp.empid}</td><td>{emp.name}</td><td>{emp.gender}</td>
        </tr>
    });
}




    return <div>
        <Link to='/home'>Home  </Link>
        <Link to='/about'>About Us  </Link>
        <Link to='/contact'>Contact Us  </Link>
        <br></br>
        <h1>Shashank first full stack app</h1>
        <br></br>
        <div>
        <table border="2" cellPadding="5px" cellSpacing="5px"><thead>
        <tr><th>Employee ID</th><th>Name</th><th>Gender</th></tr>
        </thead>
        <tbody>
            {renderList()}
        </tbody>
        </table>
        {/* <br></br>
        <input type="text" value={username} onChange={e=>setusername(e.target.value)}></input> */}
        </div>
    </div>
}

export default ViewData;