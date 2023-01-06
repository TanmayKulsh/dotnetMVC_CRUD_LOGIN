import {Link} from "react-router-dom";
const About = () => {
    return <div>
        <h1>About page</h1>
        <br></br>
        <br></br>
        <Link to="/app">
        <button type="button">Back to page</button>
        </Link>
    </div>
}

export default About;