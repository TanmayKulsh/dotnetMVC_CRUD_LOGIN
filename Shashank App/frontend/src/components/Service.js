import axios from 'axios';

class Service{
    constructor(){
        this.baseUrl="http://localhost:4000/";
   }
    
   getallemp(){
    return axios.get(this.baseUrl+"getallemp");
   }

}
export default new Service();