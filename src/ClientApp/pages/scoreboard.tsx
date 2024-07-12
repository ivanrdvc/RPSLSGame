import { Box, Container, Heading } from "@chakra-ui/react";
import Layout from "@/components/common/Layout";
import Scoreboard from "@/components/scoreboard/Scoreboard";

const Contact = () => {
  return (
    <Layout>
      <Container maxW="container.xl">
        <Box py={[5, 5, null, 10]}>
          <Heading>Scoreboard</Heading>
        </Box>
        <Scoreboard />
      </Container>
    </Layout>
  );
};

export default Contact;
