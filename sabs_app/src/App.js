import { useSelector } from "react-redux";
import { Route, Switch } from "react-router-dom";
import "./App.css";
import Dashboard from "./components/Dashboard";
import DashboardAdmin from "./components/DashboardAdmin";
import Footer from "./components/Footer";
import Header from "./components/Header";
import NotFound from "./components/NotFound";
import SectionFirstPage from "./components/SectionFirstPage";

function App() {
  const data = useSelector((state) => state.user_information);
  const { token, firstname, lastname } = data
    ? data
    : { token: undefined, firstname: undefined, lastname: undefined };
  return (
    <>
      <Header />
      <Switch>
        <Route exact path="/admin" component={DashboardAdmin} />
        <Route exact path="/" component={Dashboard} />

        <Route exact path='*' component={NotFound} />
      </Switch>
      <Footer willBeFix={token ? false : true} />
    </>
  );
}

export default App;
