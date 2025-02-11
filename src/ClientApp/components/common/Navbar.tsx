import {
  Box,
  Flex,
  HStack,
  IconButton,
  useDisclosure,
  useColorModeValue,
  Stack,
  Container,
} from "@chakra-ui/react";
import { HamburgerIcon, CloseIcon } from "@chakra-ui/icons";

interface NavlinkProps {
  children: React.ReactNode;
  path: string;
}

const NavLink = (props: NavlinkProps) => {
  const { children, path } = props;

  return (
    <Box
      as="a"
      px={2}
      py={1}
      rounded={"md"}
      _hover={{
        textDecoration: "none",
        bg: useColorModeValue("gray.200", "gray.700"),
      }}
      href={path}
    >
      {children}
    </Box>
  );
};

export default function Navbar() {
  const { isOpen, onOpen, onClose } = useDisclosure();

  return (
    <>
      <Box bg={useColorModeValue("gray.100", "gray.900")} px={4}>
        <Container maxW="container.xl">
          <Flex h={16} alignItems={"center"} justifyContent={"space-between"}>
            <IconButton
              size={"md"}
              icon={isOpen ? <CloseIcon /> : <HamburgerIcon />}
              aria-label={"Open Menu"}
              display={{ md: "none" }}
              onClick={isOpen ? onClose : onOpen}
            />
            <HStack spacing={8} alignItems={"center"}>
              <Box>RPSLS</Box>
              <HStack as={"nav"} spacing={4} display={{ base: "none", md: "flex" }}>
                <NavLink key="home" path="/">
                  Home
                </NavLink>
                <NavLink key="scoreboard" path="/scoreboard">
                  Scoreboard
                </NavLink>
              </HStack>
            </HStack>
          </Flex>

          {isOpen ? (
            <Box pb={4} display={{ md: "none" }}>
              <Stack as={"nav"} spacing={4}>
                <NavLink key="home" path="/">
                  Home
                </NavLink>
                <NavLink key="scoreboard" path="/scoreboard">
                  Scoreboard
                </NavLink>
              </Stack>
            </Box>
          ) : null}
        </Container>
      </Box>
    </>
  );
}
