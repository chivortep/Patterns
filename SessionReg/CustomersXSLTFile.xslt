<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="@* | node()">

    <h2>Customer List</h2>
    <table border="1">
      <tr>
        <th>Name</th>
        <th>Surname</th>
        <th>Age</th>
      </tr>
      
      <xsl:for-each select="customer">
        <tr>
          <td>
            <xsl:value-of select="name"/>
          </td>
          <td>
            <xsl:value-of select="surname"/>
          </td>
          <td>
            <xsl:value-of select="age"/>
          </td>
        </tr>
      </xsl:for-each>
    </table>
    <br />

  </xsl:template>
</xsl:stylesheet>