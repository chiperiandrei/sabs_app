import { Grid, TextField } from "@material-ui/core";
import Button from "@material-ui/core/Button";
import Icon from "@material-ui/core/Icon";
import AccountCircle from "@material-ui/icons/AccountCircle";
import EmailIcon from "@material-ui/icons/Email";
import LockOpenIcon from "@material-ui/icons/LockOpen";
import PhoneIcon from "@material-ui/icons/Phone";
import React from "react";
import { useForm } from "react-hook-form";
import { Col, Container, Row } from "reactstrap";

export default function SectionFirstPage() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    criteriaMode: "all",
  });

  console.log(errors);

  const onSubmit = (formData) => {
    console.log(formData);
    console.log(errors);
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
                <Grid item justify="space-between">
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
                        value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/,
                        message: "invalid email address", // JS only: <p>error message</p> TS only support string
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
                      minLength: 6,
                      message: "Minimum 6 characters",
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
                    {...register("retype_password")}
                    label="Repeat password"
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
