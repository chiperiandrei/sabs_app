import { Button, Input } from "@material-ui/core";
import axios from "axios";
import publicIp from "public-ip";
import React, { useEffect, useState } from "react";
export default function AddMyIpAdress() {
  const [ip, setIp] = useState("");
  const token = localStorage.getItem("user_info");

  const requestToAdmin = () => {
    axios.post("addIP", ip, {
      headers: {
        Authorization: `Bearer ${token.substr(1, token.length - 2)}`,
      },
    });
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
    </>
  );
}
