import React from "react";
import { useSelector } from "react-redux";
import { WelcomeMessage, Wrapper } from "../shared/styled/GlobalStyle";
import ListUsersInTable from "./ListUsersInTable";

export default function DashboardAdmin() {
  const data = useSelector((state) => state.user_information);
  return (
    <Wrapper>
      <WelcomeMessage>
        Welcome back,{" "}
        <span id="userName"> {data.firstname ? data.firstname : null}</span>
      </WelcomeMessage>
      <ListUsersInTable />
    </Wrapper>
  );
}
