import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import ViewData from "./components/ViewData"
import Home from "./components/Home";
import About from "./components/About";
import Contact from "./components/Contact";
function App() {
  return (
    <>
    
    
    
      <Router>
        <Switch>           
          <Route path="/app"  component={ViewData} ></Route>
          <Route path="/home"  component={Home} ></Route>
          <Route path="/about"  component={About} ></Route>
          <Route path="/contact"  component={Contact} ></Route>
        </Switch>
      </Router>
    </>
  );
}

export default App;
