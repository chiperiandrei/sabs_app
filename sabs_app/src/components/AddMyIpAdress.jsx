import { Button, Input } from "@material-ui/core";
import axios from "axios";
import publicIp from "public-ip";
import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { toast, ToastContainer } from "react-toastify";
export default function AddMyIpAdress() {
  const [ip, setIp] = useState("");
  const token = localStorage.getItem("user_info");

  const data = useSelector((state) => state.user_information);

  const requestToAdmin = () => {
    axios
      .post(
        "https://localhost:5001/api/pendingip",
        { email: data?.email, ipadress: ip },
        {
          headers: {
            Authorization: `Bearer ${token.substr(1, token.length - 2)}`,
          },
        }
      )
      .then((res) => toast.success(`Request for ${ip} is now created `))
      .catch((err) => toast.error("Error during request ip"));
  };

  useEffect(async () => {
    setIp(
      await publicIp.v4({
        fallbackUrls: ["https://ifconfig.co/ip"],
      })
    );
  });

  return (
    <>
      Your current IP is <br />
      <Input value={ip} disabled={true} />
      <Button onClick={requestToAdmin}>Add to list</Button>
      <ToastContainer autoClose={2000} />
    </>
  );
}
