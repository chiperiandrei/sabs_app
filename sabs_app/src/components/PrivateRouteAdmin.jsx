import React from "react";
import { Redirect, Route } from "react-router-dom";
import { isAdmin } from "../utils";
import DashboardAdmin from "./DashboardAdmin";

const PrivateRouteAdminPanel = ({ component: Component, ...rest }) => {
    return (
        <Route {...rest} render={props => (
            isAdmin() ?
                <DashboardAdmin {...props} />
                : <Redirect to="/" />
        )} />
    );
};
export default PrivateRouteAdminPanel;