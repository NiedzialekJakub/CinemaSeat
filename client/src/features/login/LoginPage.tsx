import { Button, Container, Typography } from "@mui/material";
import { NavLink } from "react-router";

export default function LoginPage() {
  return (
    <Container sx={{mt: 3}}>
        <Typography sx={{color: 'white'}} variant="h3">Login Page</Typography>
        <Button component={NavLink} to='/films' size="large">Films</Button>
    </Container>
  )
}
