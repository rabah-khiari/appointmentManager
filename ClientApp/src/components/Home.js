import Delete from "./Delete";
import Edite from "./Edite";
import New from "./New";

export default function Home()
{
    return (
        <div> 

          <section className="row justify-btw items-center filtred" >
             

          </section>
            <Edite/>
            <New/>
            <Delete/>
            
        </div>
    );
}