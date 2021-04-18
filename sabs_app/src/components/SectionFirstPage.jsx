import { Grid, TextField } from "@material-ui/core";
import Button from "@material-ui/core/Button";
import Icon from "@material-ui/core/Icon";
import AccountCircle from "@material-ui/icons/AccountCircle";
import EmailIcon from "@material-ui/icons/Email";
import LockOpenIcon from "@material-ui/icons/LockOpen";
import PhoneIcon from "@material-ui/icons/Phone";
import axios from "axios";
import React, { useRef } from "react";
import { useForm } from "react-hook-form";
//notifications
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Col, Container, Row } from "reactstrap";

export default function SectionFirstPage() {
  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
    reset,
  } = useForm({
    criteriaMode: "all",
  });

  console.log(errors);
  const password = useRef({});
  password.current = watch("password", "");

  const onSubmit = ({ email, password, firstname, lastname, phone }, e) => {
    const register_data = { email, password, firstname, lastname, phone };
    console.log(register_data);
    axios
      .post("https://localhost:5001/api/user/register", register_data)
      .then((res) => {
        toast.success("Account successfully created!");
        e.target.reset();
      })
      .catch((err) => toast.error(err.message));
  };
  return (
    <section className="s2">
      <Container>
        <Row className="flex-align">
          <Col md="7" lg="5" className="s2__des">
            <h1>
              <span className="bold">Join US</span>
            </h1>
            <form onSubmit={handleSubmit(onSubmit)}>
              <Grid container spacing={2} direction="column">
                <Grid item>
                  <AccountCircle />
                  <TextField
                    name="firstname"
                    type="text"
                    label="Firstname"
                    {...register("firstname", {
                      required: "Firstname is required",
                    })}
                    error={errors.firstname ? true : false}
                    helperText={
                      errors.firstname ? errors.firstname.message : null
                    }
                  />
                </Grid>
                <Grid item>
                  <AccountCircle />
                  <TextField
                    name="lastname"
                    type="text"
                    label="Lastname"
                    {...register("lastname", {
                      required: "Lastname is required",
                    })}
                    error={errors.lastname ? true : false}
                    helperText={
                      errors.lastname ? errors.lastname.message : null
                    }
                  />
                </Grid>
                <Grid item>
                  <PhoneIcon />
                  <TextField
                    name="phone"
                    type="text"
                    {...register("phone", {
                      pattern: {
                        value: /[0-9]{10}$/,
                        message: "Phone should be format from 10 numbers", // JS only: <p>error message</p> TS only support string
                      },
                    })}
                    label="Phone number"
                    error={errors.phone ? true : false}
                    helperText={errors.phone ? errors.phone.message : null}
                  />
                </Grid>
                <Grid item>
                  <EmailIcon />
                  <TextField
                    name="email"
                    type="email"
                    {...register("email", {
                      pattern: {
                        value: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/,
                        message: "invalid email adress",
                      },
                    })}
                    label="Email"
                    error={errors.email ? true : false}
                    helperText={errors.email ? errors.email.message : null}
                  />
                </Grid>
                <Grid item>
                  <LockOpenIcon />
                  <TextField
                    name="password"
                    type="password"
                    {...register("password", {
                      required: "You must specify a password",
                      minLength: {
                        value: 8,
                        message: "Password must have at least 8 characters",
                      },
                    })}
                    label="Password"
                    error={errors.password ? true : false}
                    helperText={
                      errors.password ? errors.password.message : null
                    }
                  />
                </Grid>
                <Grid item>
                  <LockOpenIcon />
                  <TextField
                    name="retype_password"
                    type="password"
                    {...register("retype_password", {
                      validate: (value) =>
                        value === password.current ||
                        "The passwords do not match",
                    })}
                    label="Repeat password"
                    error={errors.retype_password ? true : false}
                    helperText={
                      errors.retype_password
                        ? errors.retype_password.message
                        : null
                    }
                  />
                </Grid>
              </Grid>
              <Button
                variant="contained"
                color="primary"
                endIcon={<Icon>send</Icon>}
                style={{ marginTop: 20 }}
                type="submit"
              >
                Send
              </Button>
            </form>
          </Col>
        </Row>
        <ToastContainer autoClose={2000} />
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
