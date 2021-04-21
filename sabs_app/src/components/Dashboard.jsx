import axios from "axios";
import React from "react";
import { useSelector } from "react-redux";
import { WelcomeMessage, Wrapper } from "../shared/styled/GlobalStyle";
import AddMyIpAdress from "./AddMyIpAdress";
import ListMyIPs from "./ListMyIPs";
import SectionFirstPage from "./SectionFirstPage";

export default function Dashboard() {
  const data = useSelector((state) => state.user_information);
  const { id, firstname, lastname } = data
    ? data
    : { id: undefined, firstname: undefined, lastname: undefined };

  return id ? (
    <Wrapper>
      <WelcomeMessage>
        Welcome back, <span id="userName"> {data?.firstname}</span>
      </WelcomeMessage>
       <AddMyIpAdress/>
      <ListMyIPs/>
    </Wrapper>
  ) : (
    <SectionFirstPage />
  );
}
