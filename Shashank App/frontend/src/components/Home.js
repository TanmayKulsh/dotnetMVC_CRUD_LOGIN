import {Link} from "react-router-dom";
const Home = () => {
    return <div>
        <h1>Home page</h1>
        <br></br>
        <br></br>
        <Link to="/app">
        <button type="button">Back to page</button>
        </Link>
    </div>
}

export default Home;