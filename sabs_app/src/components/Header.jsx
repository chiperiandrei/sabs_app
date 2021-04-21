import axios from "axios";
import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import "../../src/shared/css/Header.css";
import { logInUser, logOutUser } from "../actions/userActions";
import Logo from "./Logo";
export default function Header() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const data = useSelector((state) => state.user_information);
  const { id, firstname, lastname } = data
    ? data
    : { id: undefined, firstname: undefined, lastname: undefined };
  const dispatch = useDispatch();
  const handleLogin = async (e) => {
    e.preventDefault();
    //login goes here

    axios
      .post("https://localhost:5001/api/user/login", { email, password })
      .then((res) => {
        console.log(res.data);
        dispatch(logInUser(res.data.token));
      })
      .catch((err) => console.log(err.message));
  };
  const handleLogOut = (e) => {
    dispatch(logOutUser());
    e.preventDefault();
  };
  return (
    <nav className="navbar navbar-expand-xl navbar-dark bg-dark">
      <Logo />
      <button
        type="button"
        className="navbar-toggler"
        data-toggle="collapse"
        data-target="#navbarCollapse"
      >
        <span className="navbar-toggler-icon"></span>
      </button>
      <div
        id="navbarCollapse"
        className="collapse navbar-collapse justify-content-start"
      >
        <form className="navbar-form form-inline">
          <div className="input-group search-box">
            <input
              type="text"
              id="search"
              className="form-control"
              placeholder="Search here..."
            />
            <span className="input-group-addon">
              <i className="material-icons">&#xE8B6;</i>
            </span>
          </div>
        </form>
        {id !== undefined ? (
          <div className="navbar-nav ml-auto">
            <a href="#" className="nav-item nav-link active">
              <i className="fa fa-home"></i>
              <span>Home</span>
            </a>
            <a href="#" className="nav-item nav-link">
              <i className="fa fa-gears"></i>
              <span>Projects</span>
            </a>
            <a href="#" className="nav-item nav-link">
              <i className="fa fa-users"></i>
              <span>Team</span>
            </a>
            <a href="#" className="nav-item nav-link">
              <i className="fa fa-pie-chart"></i>
              <span>Reports</span>
            </a>
            <a href="#" className="nav-item nav-link">
              <i className="fa fa-briefcase"></i>
              <span>Careers</span>
            </a>
            <a href="#" className="nav-item nav-link">
              <i className="fa fa-envelope"></i>
              <span>Messages</span>
            </a>
            <a href="#" className="nav-item nav-link">
              <i className="fa fa-bell"></i>
              <span>Notifications</span>
            </a>
            <div className="nav-item dropdown">
              <a
                href="#"
                data-toggle="dropdown"
                className="nav-item nav-link dropdown-toggle user-action"
              >
                <img
                  src={process.env.PUBLIC_URL + "logo192.png"}
                  className="avatar"
                  alt="Avatar"
                />
                {firstname} {lastname} <b className="caret"></b>
              </a>
              <div className="dropdown-menu">
                <a href="#" className="dropdown-item">
                  <i className="fa fa-user-o"></i> Profile
                </a>
                <a href="#" className="dropdown-item">
                  <i className="fa fa-calendar-o"></i> Calendar
                </a>
                <a href="#" className="dropdown-item">
                  <i className="fa fa-sliders"></i> Settings
                </a>
                <div className="divider dropdown-divider"></div>
                <a className="dropdown-item" onClick={handleLogOut}>
                  <i className="material-icons">&#xE8AC;</i> Logout
                </a>
              </div>
            </div>
          </div>
        ) : (
          <div className="navbar-nav ml-auto">
            <div className="nav-item dropdown">
              <a
                href="#"
                data-toggle="dropdown"
                className="nav-item nav-link dropdown-toggle user-action"
              >
                <img
                  src={process.env.PUBLIC_URL + "logo192.png"}
                  className="avatar"
                  alt="Avatar"
                />
                Sign into SABS_APP <b className="caret"></b>
              </a>
              <div className="dropdown-menu">
                <input
                  type="text"
                  placeholder="email"
                  className="input_login"
                  onChange={(e) => setEmail(e.target.value)}
                />
                <input
                  type="password"
                  placeholder="******"
                  className="input_login"
                  onChange={(e) => setPassword(e.target.value)}
                />
                <div className="divider dropdown-divider"></div>
                <button
                  className="btn btn-success"
                  onClick={handleLogin}
                  style={{ backgroundColor: "#926dde" }}
                >
                  Login
                </button>
              </div>
            </div>
          </div>
        )}
      </div>
    </nav>
  );
}
