import { Modal } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import HighlightOffIcon from "@material-ui/icons/HighlightOff";
import axios from "axios";
import MaterialTable from "material-table";
import React, { useEffect, useState } from "react";
const useStyles = makeStyles((theme) => ({
  paper: {
    position: "absolute",
    width: 400,
    backgroundColor: theme.palette.background.paper,
    border: "2px solid #000",
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
  },
}));

export default function ListUsersInTable() {
  const [open, setOpen] = useState(false);
  const [rowName, setRowName] = useState(null);
  const [users, setUsers] = useState(null);
  const classes = useStyles();
  const token = localStorage.getItem("user_info");

  const handleClose = () => {
    setOpen(false);
  };

  const deleteThisIp = (ip) => {
    console.log(ip);
    //@TODO here goes ip delete
  };

  const body = (
    <div
      style={{
        left: "40%",
        top: "25%",
        position: "fixed",
      }}
      className={classes.paper}
    >
      <h2 id="simple-modal-title">{rowName?.firstName}'s IPs</h2>
      <ul>
        {rowName?.iPs?.map((ip) => (
          <div style={{ display: "flex", flexWrap: "wrap" }}>
            <li key={ip.id} style={{ flex: "50%" }}>
              {ip.ipValue}
            </li>
            <HighlightOffIcon
              color={"error"}
              style={{ flex: "50%" }}
              onClick={() => deleteThisIp(ip.ipValue)}
            />
          </div>
        ))}
      </ul>
    </div>
  );

  const fetchUsers = () => {
    return axios.get("https://localhost:5001/api/user", {
      headers: {
        Authorization: `Bearer ${token.substr(1, token.length - 2)}`,
      },
    });
  };

  useEffect(async () => {
    const response = await fetchUsers();
    setUsers(response?.data);
  });
  return (
    <>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="simple-modal-title"
        aria-describedby="simple-modal-description"
      >
        {body}
      </Modal>
      <MaterialTable
        title="List Users"
        columns={[
          { title: "LastName", field: "lastName" },
          { title: "Firstname", field: "firstName" },
          { title: "Phone", field: "phone", type: "numeric" },
          {
            title: "Email",
            field: "email",
          },
        ]}
        data={
          users
            ? users
            : [
                {
                  lastName: "DUMMY",
                  firstName: "DUMMY",
                  phone: 1987,
                  email: 63,
                },
              ]
        }
        actions={[
          {
            icon: "edit",
            tooltip: "Edit User",
            onClick: (event, rowData) => {
              setOpen(!open);
              setRowName(rowData);
              console.log(rowData);
            },
          },
        ]}
      />
    </>
  );
}
