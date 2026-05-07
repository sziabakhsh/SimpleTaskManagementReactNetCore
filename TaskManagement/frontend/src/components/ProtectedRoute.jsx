import { useContext } from "react";
import { Navigate } from "react-router-dom";
import { AccountContext } from "../contexts/AccountContext";

export default function ProtectedRoute({ children }) {

  const { user } = useContext(AccountContext);

  if (!user) {
    return <Navigate to="/login" />;
  }

  return children;
}