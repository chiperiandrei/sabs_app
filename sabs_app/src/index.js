import jwtDecode from "jwt-decode";
import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { BrowserRouter } from "react-router-dom";
import { createStore } from "redux";
import App from "./App";
import "./index.css";
import { rootReducer } from "./reducers/rootReducers";

function loadUserFromLocalStorage() {
  const user = JSON.parse(localStorage.getItem("user_info"));

  if (user === null) {
    return undefined;
  }

  return jwtDecode(user);
}

const user = loadUserFromLocalStorage();

const store = createStore(
  rootReducer,
  {
    user_information: user,
  },
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById("root")
);
