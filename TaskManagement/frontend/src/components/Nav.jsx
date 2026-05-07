import { useContext } from "react";
import { Link } from "react-router-dom"
import { AccountContext } from "../contexts/AccountContext";

export default function Nav() {
    const { user, logout } = useContext(AccountContext);

  return (
    <nav>
        <Link to="/">Home</Link> | 
        <Link to="/Register">Register</Link> | 

         {!user ? (
           <Link to="/Login">Login</Link>
            ) : (
        <>
          <button onClick={logout}>
            Logout
          </button>
        </>
      )} | 

        <Link to="/Tasks" >Task Lists</Link>

    </nav>
  )
}
