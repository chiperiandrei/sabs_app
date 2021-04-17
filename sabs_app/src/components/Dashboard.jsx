import React from "react";
import { useSelector } from "react-redux";
import { WelcomeMessage, Wrapper } from "../shared/styled/GlobalStyle";
import SectionFirstPage from "./SectionFirstPage";

export default function Dashboard() {
  const data = useSelector((state) => state.user_information);
  const { token, firstname, lastname } = data
    ? data
    : { token: undefined, firstname: undefined, lastname: undefined };

  return token ? (
    <Wrapper>
      <WelcomeMessage>
        Welcome back, <span id="userName"> {data?.firstname}</span>
      </WelcomeMessage>
    </Wrapper>
  ) : (
    <SectionFirstPage />
  );
}
