import { FormControl, Grid, TextField } from "@material-ui/core";
import Button from "@material-ui/core/Button";
import Icon from "@material-ui/core/Icon";
import AccountCircle from "@material-ui/icons/AccountCircle";
import EmailIcon from "@material-ui/icons/Email";
import LockOpenIcon from "@material-ui/icons/LockOpen";
import PhoneIcon from "@material-ui/icons/Phone";
import React, { useState } from "react";
import { Col, Container, Row } from "reactstrap";

export default function SectionFirstPage() {
  const [firstname, setFirstname] = useState("");
  const [lastname, setLastname] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [repeatPassword, setRepeatPassword] = useState(null);

  const [firstnameError, setFirstnameError] = useState("");
  const [lastnameError, setLastnameError] = useState("");
  const [emailError, setEmailError] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [phoneNumberError, setPhoneNumberError] = useState("");
  const [repeatPasswordError, setRepeatPasswordError] = useState("");

  const handleRegister = () => {};
  return (
    <section className="s2">
      <Container>
        <Row className="flex-align">
          <Col md="7" lg="5" className="s2__des">
            <h1>
              <span className="bold">Join US</span>
            </h1>
            <FormControl margin="normal">
              <Grid container spacing={2} direction="column">
                <Grid item justify="space-between">
                  <AccountCircle />
                  <TextField
                    label="Firstname"
                    onChange={(e) => setFirstname(e.target.value)}
                  />
                </Grid>
                <Grid item>
                  <AccountCircle />
                  <TextField
                    label="Lastname"
                    onChange={(e) => setLastname(e.target.value)}
                  />
                </Grid>
                <Grid item>
                  <PhoneIcon />
                  <TextField
                    label="Phone number"
                    onChange={(e) => setPhoneNumber(e.target.value)}
                  />
                </Grid>
                <Grid item>
                  <EmailIcon />
                  <TextField
                    required={true}
                    type="email"
                    label="Email"
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </Grid>
                <Grid item>
                  <LockOpenIcon />
                  <TextField
                    label="Password"
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </Grid>
                <Grid item>
                  <LockOpenIcon />
                  <TextField
                    label="Repeat password"
                    onChange={(e) => setRepeatPassword(e.target.value)}
                  />
                </Grid>
              </Grid>
              <Button
                variant="contained"
                color="primary"
                endIcon={<Icon>send</Icon>}
                onClick={handleRegister}
              >
                Send
              </Button>
            </FormControl>
          </Col>
        </Row>
      </Container>
      <style>{`
        .s2 {
            font-size: 16px;
            margin-top: 4em;
        }
        .s2__mob-pic {
            margin-bottom: 4em;
        }
        @media (min-width: 768px) {
            .s2__mob-pic {
            margin-bottom: 0;
            }
        }
        
        .s2__mob-pic img {
            max-width: 100%;
        }
        .s2__des h1 {
            font-size: 2.6em;
            font-weight: 100;
            letter-spacing: 2.5px;
        }
        .s2__des .bold{
            font-weight: 700;
        }
        .s2__des p {
            font-weight: 100;
            font-size: .95em;
            line-height: 1.8;
        }
        .s2__des ul {
            font-weight: 100;
            font-size: .9em;
            letter-spacing: 1.5px;
            list-style: none;
            padding: 0;
        }
         .s2__list > li {
            padding: .5em 0;
        }
        .s2__list i {
            margin-right: 1em;
        }
        @media (min-width: 768px) {
            .flex-align {
                justify-content: center;
                align-items: center;
            }
        }
    
    `}</style>
    </section>
  );
}
